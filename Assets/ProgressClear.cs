using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressClear : MonoBehaviour
{
    public void Update()
    {
        if (!Input.GetKeyDown(KeyCode.O)) return;

        PlayerPrefs.SetInt("LvlAch" + 0, 0);
        PlayerPrefs.SetInt("LvlAch" + 1, 0);
        PlayerPrefs.SetInt("LvlAch" + 2, 0);
        PlayerPrefs.SetInt("LvlAch" + 3, 0);
        PlayerPrefs.SetInt("LvlAch" + 4, 0);
        PlayerPrefs.SetInt("LvlAch" + 5, 0);
    }
}
