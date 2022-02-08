using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class DialogCutscene : MonoBehaviour
{
    public AnimationPrintText animationPrint;
    public string sceneName; // Имя сцены, на которую мы перходим
    public GameObject dialogueImg; // Блок, на котором отображается текст
    public GameObject text;
    public GameObject nameImg; // Блок, на котором отображается текст
    public GameObject nameText;
    public float hideSpeed = 1f; // Скорость появления элементов
    public float startWait = 5f; // Задержка перед первым появлением текста
    public float spawnTime = 0.1f;
    public string[] texts; // Массив фраз
    private int i = 0; // id массива
    private bool sceneSkipPause = false; // Контроль кнопки пропуска (чтобы с появлением кнопки сразу не сменилась сцена)
    private bool stopScrollText = false; // Контроль смены текста (чтобы не листать его до того, как он появится)

    public void Start()
    {
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        StartCoroutine(StartMainDialogue()); // Запускаем первое появление
    }
    public void KeyControl()
    {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.Mouse0))
            StartCoroutine(TimeStop()); // ставим задержку, после которой можно будет пропустить

        if (sceneSkipPause && Input.GetKeyDown(KeyCode.E)) NextScene();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            if (stopScrollText) NextText(); // Если контроллер смены текста тру, то сменяем текст
    }
    public void NextText() // Подпрограмма смены текста
    {
        if (i < texts.Length) // Пока мы не достигли конца массива
        {
            animationPrint.StartAnimation(texts[i], text.GetComponent<Text>(), spawnTime); // меняем текст
            i++;
        }
        else NextScene(); // Если достигли конца массива, переходим к следующей сцене
    }
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.4f); // Делаем паузу
        sceneSkipPause = true; // Меняем контроллер пропуска
    }
    IEnumerator StartMainDialogue()
    {
        yield return new WaitForSeconds(startWait); // Делаем первую задержку перед появлением плашки
        Cursor.visible = true;
        animationPrint.StartAnimation(texts[i], text.GetComponent<Text>(), spawnTime);
        i++;
        ShowObg(true); // Показываем плашку с текстом
    }
    public void ShowObg(bool show) // Функция, которая принимает логическую переменную, в зависимости от которой объект скроется или появится
    {
        byte alphaChannel = 0;
        if (show) alphaChannel = 255;
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // Меняем прозрачность объекта
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // Меняем прозрачность текста, если он есть
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        stopScrollText = true; // Меняем контроллер смены текста
    }
    public void NextScene()
    {
        SceneManager.LoadScene(sceneName); // запуск новой сцены
    }
    void Update()
    {
        KeyControl(); // постоянно проверяем нажатие клавиш 
    }
}


