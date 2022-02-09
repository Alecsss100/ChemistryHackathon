using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Chemistry/DialogScriptableObj", order = 1)]
public class DialogPhrase : ScriptableObject
{
    public bool side; //������� � ������� �������� ���
    public string talkedFace; //�������� ������� �������
    [TextArea(0,8)] public string text; //����� ������� �������� �������
}
