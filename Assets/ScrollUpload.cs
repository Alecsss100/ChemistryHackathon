using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollUpload : MonoBehaviour
{
    [SerializeField] Scrollbar bar;
    [SerializeField] Inventory inventory;

    [SerializeField] bool horizontal;

    public void OnValueChanged()
    {
        if (horizontal)
            inventory.SetScrollHorizontal(bar.value);
        else inventory.SetScrollVertical(bar.value);
    }
}
