using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IButton : IPointerClickHandler
{
    public void DoAction(System.Action action);
}
