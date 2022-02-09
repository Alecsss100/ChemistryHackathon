using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public string nameScene;
    public void SwitchLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }
}
