using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] ScrollRect scroll;
    [SerializeField] Animator invAnimator;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            LockInventory();
        }
    }

    public void SetScrollHorizontal(float value)
    {
        scroll.horizontalNormalizedPosition = value;
    }

    public void SetScrollVertical(float value)
    {
        scroll.verticalNormalizedPosition = value;
    }

    public void ShowInventory()
    {
        invAnimator.Play("Show");
    }

    public void LockInventory()
    {
        scroll.enabled = false;
    }

    public void UnlockInventory()
    {
        scroll.enabled = true;
    }
}
