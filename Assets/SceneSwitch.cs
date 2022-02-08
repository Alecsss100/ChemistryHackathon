using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] string nameScene;
    public void SwitchLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }
}
