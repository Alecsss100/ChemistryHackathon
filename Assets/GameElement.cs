using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameElement : MonoBehaviour
{
    [SerializeField] Element element;

    [SerializeField] Text ChemestryName;
    [SerializeField] Text SampleName;
    [SerializeField] Text AtomicName;
    [SerializeField] Image ViewElement;

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
        ViewElement.color = new Color(0,0,0,0);
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
        if (!element) return;
        MovebleElement.Init(this);
    }
}
