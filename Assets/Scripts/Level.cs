using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] LevelEnum.Level levelId;
    [SerializeField] Image childImage;
    private void Start()
    {
        Debug.Log("Дописать для бг чтоб серым становился");
        if ((int)levelId <= LvlController.LevelCounter) Unlock();
        else Lock();
    }

    private void Unlock()
    {
        childImage.color = new Color(childImage.color.r, childImage.color.g, childImage.color.b, 1);
    }

    private void Lock()
    {
        childImage.color = new Color(childImage.color.r, childImage.color.g, childImage.color.b, 0);
    }
}
