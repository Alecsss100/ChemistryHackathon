using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    [SerializeField] Animator sceneSwitch;

    private static int levelCounter = 3;
    private static int curLevel;
    public static int LevelCounter
    {
        get
        {
            return levelCounter;
        }
        private set
        {
            if (value > 6 || value < 0) return;

            levelCounter = value;
        }
    }

    private static LvlController instance;
    public void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public static int GetCurrentLvl()
    {
        return LevelCounter;
    }

    public static void LvlUp()
    {
        LevelCounter += 1;
    }

    public static void LoadScene(int lvlIndex)
    {
        curLevel = lvlIndex;
        Transition.PlayCommand("Game");
        instance.sceneSwitch.Play("SwitchLevelDown");
    }
}