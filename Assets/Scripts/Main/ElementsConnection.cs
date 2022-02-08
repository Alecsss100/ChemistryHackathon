using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "[H]+[H]=[HH]", menuName = "Chemistry/ConnectionScriptableObj", order = 1)]
public class ElementsConnection : ScriptableObject
{
    [SerializeField] Element[] combinedElements;
    [SerializeField] Element resultElement;

    public bool CheckCombo(List<Element> elements)
    {
        List<Element> listInput = new List<Element>(elements);
        List<Element> listCur = new List<Element>(combinedElements);

        listInput.Sort();
        listCur.Sort();

        if (listInput.Count != listCur.Count) return false;

        for (int i = 0; i < listCur.Count; i++)
            if (!listCur[i].EqualsElements(listInput[i])) return false;

        return true;
    }
}
