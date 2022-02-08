using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private static string switchLevel = "SwitchLevel";
    private static string switchLevelBack = "SwitchLevelBack";

    private static string command;

    public void Awake()
    {
        if (command != null)
        GetComponent<Animator>().Play(command);
    }

    public static void SwitchLevel()
    {
        command = switchLevel;
    }

    public static void SwitchLevelBack()
    {
        command = switchLevelBack;
    }
    public static void Stay()
    {
        command = null;
    }
}
