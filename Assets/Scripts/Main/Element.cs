using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ElementEnum;

[CreateAssetMenu(fileName = "Element", menuName = "Chemistry/ElementScriptableObj", order = 1)]
public class Element : ScriptableObject, IComparable<Element>
{
    [SerializeField] ChemestryName nameId;

    [Tooltip("Атомный/Порядковый номер элемента")]
    [Min(0)] public int atomicNumber;

    [Tooltip("Электроотрицательность элемента")]
    [Min(0)] public float electronegativity;

    [Tooltip("Относительная атомная масса")]
    public float atomicMass;

    [Tooltip("Химический Символ")]
    public string nameChemestry;

    [Tooltip("Название элемента")]
    public string nameElement;

    [Tooltip("Спрайт элемента")]
    public Sprite sprite;

    [Tooltip("Описание элемента")]
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
