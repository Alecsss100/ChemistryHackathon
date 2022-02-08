using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button : IButton
{
    public void DoAction(Action action)
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DoAction(()=>SceneManager.LoadScene(0));
    }
}
