using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlController : MonoBehaviour
{
    private static int levelCounter = 0;
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
}
