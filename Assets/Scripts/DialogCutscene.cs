using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;

public class DialogCutscene : MonoBehaviour
{
    //public AnimationPrintText animationPrint;
    public GameObject dialogueImg; // Блок, на котором отображается текст
    public GameObject text;
    public GameObject nameImg; // Блок, на котором отображается текст
    public GameObject nameText;
    public float hideSpeed = 1f; // Скорость появления элементов
    public float startWait = 5f; // Задержка перед первым появлением текста
    public float spawnTime = 0.1f;
    public string[] texts; // Массив фраз
    private int i = 0; // id массива
    private bool nextDoPause = false; // Контроль кнопки пропуска (чтобы с появлением кнопки сразу не сменилась сцена)
    private bool stopScrollText = false; // Контроль смены текста (чтобы не листать его до того, как он появится)
    private bool stopTextCoroutine = false; // Контроль смены текста (чтобы не листать его до того, как он появится)
    private float timer = 0;

    void NextDo()// точка выхода
    {
        // что должно быть дальше
    }

    public void Start()
    {
        StartDialog();
    }
    public void StartDialog() // точка входа
    {
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        StartCoroutine(StartMainDialogue()); // Запускаем первое появление
    }
    void KeyControl()
    {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.Mouse0))
            StartCoroutine(TimeStop()); // ставим задержку, после которой можно будет пропустить

        if (nextDoPause && Input.GetKeyDown(KeyCode.E)) NextDo();

        if (Input.GetKeyDown(KeyCode.Space) && stopTextCoroutine)
        {
            stopTextCoroutine = false;
            if (stopScrollText) NextText(); // Если контроллер смены текста тру, то сменяем текст
        }
    }
    void NextText() // Подпрограмма смены текста
    {
        if (i < texts.Length) // Пока мы не достигли конца массива
        {
            stopTextCoroutine = true;
            TextCoroutine(texts[i], text.GetComponent<Text>(), spawnTime); // меняем текст
            i++;
        }
        else NextDo(); // Если достигли конца массива, переходим к следующей сцене
    }
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.4f); // Делаем паузу
        nextDoPause = true; // Меняем контроллер пропуска
    }
    IEnumerator StartMainDialogue()
    {
        yield return new WaitForSeconds(startWait); // Делаем первую задержку перед появлением плашки
        Cursor.visible = true;
        stopTextCoroutine = true;
        ShowObg(true); // Показываем плашку с текстом
        NextText();
    }
    void TextCoroutine(string text, Text uiText, float spawnTime)
    {
        //uiText.text = "";
        //for (int j = 0; j < text.Length;)
        //{
        //    if (Wait(spawnTime))
        //    {
        //        uiText.text += text[j];
        //        timer = 0;
        //        j++;
        //    }
        //    print(uiText.text);
        //}
        uiText.text = text;
    }
    //bool Wait(float seconds)
    //{
    //    float timerMax = seconds;
    //    timer += Time.deltaTime;
    //    return timer >= timerMax;
    //}
    void ShowObg(bool show) // Функция, которая принимает логическую переменную, в зависимости от которой объект скроется или появится
    {
        byte alphaChannel = 0;
        if (show) alphaChannel = 255;
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // Меняем прозрачность объекта
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // Меняем прозрачность текста, если он есть
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        stopScrollText = true; // Меняем контроллер смены текста
    }
    
    void Update()
    {
        KeyControl(); // постоянно проверяем нажатие клавиш 
    }
}


