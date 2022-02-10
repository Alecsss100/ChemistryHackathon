using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Discription : MonoBehaviour
{
    [SerializeField] Text curText;

    private string showUp = "ShowUp";
    private string showDown = "ShowDown";
    private string reShow = "ReShow";

    private string text;

    private bool active = false;

    Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlaceText(string text)
    {
        this.text = text;
    }

    public void SetText()
    {
        curText.text = text;
    }

    public void ShowText()
    {
        if (active == true) { animator.Play(reShow); return; }
        active = true;
        animator.Play(showUp);
    }
    
    public void HideText()
    {
        animator.Play(showDown);
    }

}
