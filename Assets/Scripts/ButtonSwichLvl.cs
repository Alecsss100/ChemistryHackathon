using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonSwichLvl : IButton
{
    [SerializeField] string sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneName);
    }
}
