using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] MovebleElement moveElement;

    private static GameController instance;

    public void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    public void Start()
    {
        StartBattle();
    }

    public static void StartDialog()
    {

    }

    public static void EndDialog()
    {

    }

    public static void StartBattle()
    {
        instance.inventory.ShowInventory();
    }

    public static void Win()
    {
        LvlController.LvlUp();
    }

    public static void Lose()
    {

    }

    public static void GetAchive()
    {

    }
}
