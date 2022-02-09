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
        StartDialog();
    }

    public static void StartDialog()
    {

    }

    public static void NextCharacter()
    {

    }

    public static void EndDialog()
    {
        StartBattle();
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

    IEnumerator Wait(System.Action action, float seconds = 1)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
