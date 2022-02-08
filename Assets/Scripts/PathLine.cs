using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathLine : MonoBehaviour
{
    [SerializeField] Image pathLight;
    [SerializeField] LevelEnum.Level levelId;

    private void Start()
    {
        if ((int)levelId < LvlController.LevelCounter) Unlock();
        else Lock();
    }

    private void Unlock()
    {
        pathLight.color = new Color(pathLight.color.r, pathLight.color.g, pathLight.color.b, 1);
    }

    private void Lock()
    {
        pathLight.color = new Color(pathLight.color.r, pathLight.color.g, pathLight.color.b, 0);
    }

    public int GetLvlId()
    {
        return (int)levelId;
    }
}
