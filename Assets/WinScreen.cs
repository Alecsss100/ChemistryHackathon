using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] Image stone;
    [SerializeField] Text text;

    string stoneRuby = "�� �������� �����";
    string stoneQuartz = "�� �������� �����";
    string stoneMahit = "�� �������� �������";

    public void SwitchStone()
    {
        stone.sprite = LvlController.GetMark(GameController.GetHp());
        stone.SetNativeSize();
        switch (GameController.GetHp())
        {
            case 1:
                text.text = stoneRuby;
                break;
            case 2:
                text.text = stoneQuartz;
                break;
            case 3:
                text.text = stoneMahit;
                break;
        }
    }
}
