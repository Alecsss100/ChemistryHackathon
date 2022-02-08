using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class DialogCutscene : MonoBehaviour
{
    public AnimationPrintText animationPrint;
    public string sceneName; // ��� �����, �� ������� �� ��������
    public GameObject dialogueImg; // ����, �� ������� ������������ �����
    public GameObject text;
    public GameObject nameImg; // ����, �� ������� ������������ �����
    public GameObject nameText;
    public float hideSpeed = 1f; // �������� ��������� ���������
    public float startWait = 5f; // �������� ����� ������ ���������� ������
    public float spawnTime = 0.1f;
    public string[] texts; // ������ ����
    private int i = 0; // id �������
    private bool sceneSkipPause = false; // �������� ������ �������� (����� � ���������� ������ ����� �� ��������� �����)
    private bool stopScrollText = false; // �������� ����� ������ (����� �� ������� ��� �� ����, ��� �� ��������)

    public void Start()
    {
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, 0), 0);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, 0), 0);
        StartCoroutine(StartMainDialogue()); // ��������� ������ ���������
    }
    public void KeyControl()
    {
        if (Input.anyKeyDown && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Return) && !Input.GetKey(KeyCode.Mouse0))
            StartCoroutine(TimeStop()); // ������ ��������, ����� ������� ����� ����� ����������

        if (sceneSkipPause && Input.GetKeyDown(KeyCode.E)) NextScene();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            if (stopScrollText) NextText(); // ���� ���������� ����� ������ ���, �� ������� �����
    }
    public void NextText() // ������������ ����� ������
    {
        if (i < texts.Length) // ���� �� �� �������� ����� �������
        {
            animationPrint.StartAnimation(texts[i], text.GetComponent<Text>(), spawnTime); // ������ �����
            i++;
        }
        else NextScene(); // ���� �������� ����� �������, ��������� � ��������� �����
    }
    IEnumerator TimeStop()
    {
        yield return new WaitForSeconds(0.4f); // ������ �����
        sceneSkipPause = true; // ������ ���������� ��������
    }
    IEnumerator StartMainDialogue()
    {
        yield return new WaitForSeconds(startWait); // ������ ������ �������� ����� ���������� ������
        Cursor.visible = true;
        animationPrint.StartAnimation(texts[i], text.GetComponent<Text>(), spawnTime);
        i++;
        ShowObg(true); // ���������� ������ � �������
    }
    public void ShowObg(bool show) // �������, ������� ��������� ���������� ����������, � ����������� �� ������� ������ �������� ��� ��������
    {
        byte alphaChannel = 0;
        if (show) alphaChannel = 255;
        dialogueImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // ������ ������������ �������
        text.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed); // ������ ������������ ������, ���� �� ����
        nameImg.GetComponent<Image>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        nameText.GetComponent<Text>().DOColor(new Color32(255, 255, 255, alphaChannel), hideSpeed);
        stopScrollText = true; // ������ ���������� ����� ������
    }
    public void NextScene()
    {
        SceneManager.LoadScene(sceneName); // ������ ����� �����
    }
    void Update()
    {
        KeyControl(); // ��������� ��������� ������� ������ 
    }
}


