using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Level))]
public class ButtonLvlChoose : MonoBehaviour, IButton
{
    private int levelIndex;
    public void Awake()
    {
        levelIndex = GetComponent<Level>().GetLvlId();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(LvlController.GetChoosenLvl());
        LvlController.LoadScene(levelIndex);
    }
}
