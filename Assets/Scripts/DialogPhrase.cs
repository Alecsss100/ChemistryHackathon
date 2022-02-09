using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Chemistry/DialogScriptableObj", order = 1)]
public class DialogPhrase : ScriptableObject
{
    public bool side; //Сторона с которой появится имя
    public string talkedFace; //Персонаж который говорит
    [TextArea(0,8)] public string text; //Текст который персонаж говорит
}
