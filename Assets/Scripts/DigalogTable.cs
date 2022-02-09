using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigalogTable : MonoBehaviour
{
    [SerializeField] RectTransform talkerObj;
    [SerializeField] Text talkerText;
    [SerializeField] Text dialogText;

    [SerializeField] DialogPhrase[] phrases;
    private int dialogIndex = 0;

    private Animator animator;

    private string toScreen = "ToScreen";
    private string fromScreen = "FromScreen";


    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void ToScreen()
    {
        animator.Play(toScreen);
    }

    public void FromScreen()
    {
        animator.Play(fromScreen);
    }

    public bool TextShow()
    {
        if (dialogIndex >= phrases.Length) return false;
        TextShow(phrases[dialogIndex].text, phrases[dialogIndex].talkedFace, phrases[dialogIndex].side);
        dialogIndex += 1;
        return true;
    }

    public void TextShow(string text, string talkerName, bool sideRight)
    {
        talkerObj.gameObject.SetActive(true);
        if (!sideRight)
            talkerObj.anchoredPosition = new Vector2(-450, talkerObj.anchoredPosition.y);
        else talkerObj.anchoredPosition = new Vector2(450, talkerObj.anchoredPosition.y);

        talkerText.text = talkerName;
        dialogText.text = text;
    }

    public void EndDialog()
    {
        talkerText.text = "";
        dialogText.text = "";
        talkerObj.gameObject.SetActive(false);
        FromScreen();
    }
}
