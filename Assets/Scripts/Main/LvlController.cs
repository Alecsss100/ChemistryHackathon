using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    [SerializeField] Animator sceneSwitch;

    [Header("LvlMark")]
    public Sprite green;
    public Sprite yellow;
    public Sprite red;

    private static int levelCounter = 0;
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

    public static Sprite GetMark(int mark)
    {
        switch (mark)
        {
            case 1:
                return instance.red;
                break;
            case 2:
                return instance.yellow;
                break;
            case 3:
                return instance.green;
                break;
            default:
                return null;
                break;
        }
    }

    public static void SetCurrentLvl(int lvl)
    {
        curLevel = lvl;
    }

    public static int GetCurrentLvl()
    {
        return LevelCounter;
    }

    public static int GetChoosenLvl()
    {
        return curLevel;
    }

    public static void LvlUp()
    {
        LevelCounter += 1;
    }

    public static void LoadScene(int lvlIndex)
    {
        curLevel = lvlIndex;
        Transition.PlayCommand("Game"+lvlIndex);
        Transition.SwitchLevel();
        instance.sceneSwitch.Play("SwitchLevelDown");
    }
}