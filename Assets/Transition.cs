using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private static string switchLevel = "SwitchLevel";
    private static string switchLevelBack = "SwitchLevelBack";
    private static string switchLevelUp = "SwitchLevelUp";
    private static string switchLevelDown = "SwitchLevelDown";

    private static string command;

    private static Transition instance;

    public void Awake()
    {
        if (command != null)
        GetComponent<Animator>().Play(command);

        instance = this;
    }

    public static void PlayCommand(string command)
    {
        instance.GetComponent<SceneSwitch>().nameScene = command;
    }

    public static void SwitchLevel()
    {
        command = switchLevel;
    }

    public static void SwitchLevelBack()
    {
        command = switchLevelBack;
    }
    public static void SwitchLevelUp()
    {
        command = switchLevelUp;
    }
    public static void SwitchLevelDown()
    {
        command = switchLevelDown;
    }

    public static void Stay()
    {
        command = null;
    }
}
