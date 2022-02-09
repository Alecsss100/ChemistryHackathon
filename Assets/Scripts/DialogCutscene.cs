using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;

public class DialogCutscene : MonoBehaviour
{
    //public AnimationPrintText animationPrint;
    public GameObject dialogueImg; // ����, �� ������� ������������ �����
    public GameObject text;
    public GameObject nameImg; // ����, �� ������� ������������ �����
    public GameObject nameText;
    public float hideSpeed = 1f; // �������� ��������� ���������
    public float startWait = 5f; // �������� ����� ������ ���������� ������
    public float spawnTime = 0.1f;
    public string[] texts; // ������ ����
    private int i = 0; // id �������
    private bool nextDoPause = false; // �������� ������ �������� (����� � ���������� ������ ����� �� ��������� �����)
    private bool stopScrollText = false; // �������� ����� ������ (����� �� ������� ��� �� ����, ��� �� ��������)
    private bool stopTextCoroutine = false; // �������� ����� ������ (����� �� ������� ��� �� ����, ��� �� ��������)
    private float timer = 0;

    void NextDo()// ����� ������
    {
        // ��� ������ ���� ������
    }

    public void Start()
    {
        StartDialog();
    }
    public void StartDialog() // ����� �����
    {
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        StartCoroutine(StartMainDialogue()); // ��������� ������ ���������
    }
    void KeyControl()
    {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.Mouse0))
            StartCoroutine(TimeStop()); // ������ ��������, ����� ������� ����� ����� ����������

        if (nextDoPause && Input.GetKeyDown(KeyCode.E)) NextDo();

        if (Input.GetKeyDown(KeyCode.Space) && stopTextCoroutine)
        {
            stopTextCoroutine = false;
            if (stopScrollText) NextText(); // ���� ���������� ����� ������ ���, �� ������� �����
        }
    }
    void NextText() // ������������ ����� ������
    {
        if (i < texts.Length) // ���� �� �� �������� ����� �������
        {
            stopTextCoroutine = true;
            TextCoroutine(texts[i], text.GetComponent<Text>(), spawnTime); // ������ �����
            i++;
        }
        else NextDo(); // ���� �������� ����� �������, ��������� � ��������� �����
    }
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.4f); // ������ �����
        nextDoPause = true; // ������ ���������� ��������
    }
    IEnumerator StartMainDialogue()
    {
        yield return new WaitForSeconds(startWait); // ������ ������ �������� ����� ���������� ������
        Cursor.visible = true;
        stopTextCoroutine = true;
        ShowObg(true); // ���������� ������ � �������
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
    void ShowObg(bool show) // �������, ������� ��������� ���������� ����������, � ����������� �� ������� ������ �������� ��� ��������
    {
        byte alphaChannel = 0;
        if (show) alphaChannel = 255;
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // ������ ������������ �������
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // ������ ������������ ������, ���� �� ����
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        stopScrollText = true; // ������ ���������� ����� ������
    }
    
    void Update()
    {
        KeyControl(); // ��������� ��������� ������� ������ 
    }
}


