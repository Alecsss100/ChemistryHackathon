using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameElement : MonoBehaviour
{
    [SerializeField] Element element;

    [Header("Components")]
    [SerializeField] Text ChemestryName;
    [SerializeField] Text SampleName;
    [SerializeField] Text AtomicName;
    [SerializeField] Image ViewElement;
    [SerializeField] Image bgImage;

    [Header("Textures")]
    [SerializeField] Sprite defaultState;
    [SerializeField] Sprite highlightState;

    [Header("Animation")]
    [SerializeField] Animator animator;
    private string growUp = "GrowUp";
    private string growDown = "GrowDown";

    public bool mouseActive = false;

    private static GameElement currentDiscription;
    private bool curutine = false;
    private bool click = false;
    private Coroutine coroutine;

    public void Awake()
    {
        if (element) SetParam(element);
        else SetDefault();
    }

    public void Hide()
    {
        if (!element) return;
        SetDefault();
    }

    public void UnHide()
    {
        if (!element) return;
        SetParam(element);
    }

    private void SetDefault()
    {
        ChemestryName.text = "";
        SampleName.text = "";
        AtomicName.text = "";
        ViewElement.color = new Color(0, 0, 0, 0);
    }

    private void SetParam(Element element)
    {
        ChemestryName.text = element.nameChemestry;
        SampleName.text = element.nameElement;
        AtomicName.text = element.atomicNumber.ToString();
        ViewElement.sprite = element.sprite;
        ViewElement.color = new Color(1, 1, 1, 1);
        ViewElement.SetNativeSize();
    }

    public void OnMouseDown()
    {
        if (!element || mouseActive) return;

        if (coroutine == null) { click = false; coroutine = StartCoroutine(Wait()); return; }

        if (curutine) { click = true; }
    }

    public static void UnHighLightEl()
    {
        if (!currentDiscription) return;
        GameController.DisableDiscriptionText();
        currentDiscription.UnHighLight();
        currentDiscription = null;
    }

    public void Description()
    {
        if (currentDiscription != null) currentDiscription.UnDescription();
        currentDiscription = this;
        currentDiscription.bgImage.sprite = highlightState;

        GameController.PlaceTextInDiscription(element.discription);
        GameController.ShowDiscriptionText();
    }

    public void UnHighLight()
    {
        bgImage.sprite = defaultState;
    }

    public void UnDescription()
    {
        bgImage.sprite = defaultState;
    }

    public Element GetElement()
    {
        return element;
    }

    public void GrowUp()
    {
        animator.Play(growUp);
    }

    public void GrowDown()
    {
        animator.Play(growDown);
    }

    IEnumerator Wait()
    {
        curutine = true;
        yield return new WaitForSeconds(0.5f);
        curutine = false;

        if (click) Description();
        else MovebleElement.Init(this);

        coroutine = null;
    }
}
