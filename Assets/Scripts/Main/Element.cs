using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementEnum;

[CreateAssetMenu(fileName = "Element", menuName = "Chemistry/ElementScriptableObj", order = 1)]
public class Element : ScriptableObject, IComparable<Element>
{
    [SerializeField] ChemestryName nameId;

    [Tooltip("�������/���������� ����� ��������")]
    [Min(0)] public int atomicNumber;

    [Tooltip("���������������������� ��������")]
    [Min(0)] public float electronegativity;

    [Tooltip("������������� ������� �����")]
    public float atomicMass;

    [Tooltip("���������� ������")]
    public string nameChemestry;

    [Tooltip("�������� ��������")]
    public string nameElement;

    [Tooltip("������ ��������")]
    public Sprite sprite;

    [Tooltip("�������� ��������")]
    [TextArea(0, 8)] public string discription;

    public int CompareTo(Element other)
    {
        return nameId - other.nameId;
    }

    public bool EqualsElements(Element other)
    {
        return this.nameChemestry == other.nameChemestry;
    }
}
