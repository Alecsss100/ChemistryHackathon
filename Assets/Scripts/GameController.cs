using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] MovebleElement moveElement;

    [SerializeField] DigalogTable digalogTable;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;

    private System.Action action = () => instance.EndDialog();

    private static GameController instance;

    public void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    public void Start()
    {
        StartCoroutine(Wait(() => StartDialog(), 0.5f));
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            NextCharacter();
        }
    }

    public void StartDialog()
    {
        digalogTable.ToScreen();
        StartCoroutine(Wait(() =>
        {
            instance.player.ToScreen();
            instance.enemy.ToScreen();
        }, 0.5f));
    }

    public void NextCharacter()
    {
        if (!digalogTable.TextShow()) action?.Invoke();
    }

    public void EndDialog()
    {
        action = null;

        digalogTable.EndDialog();
        digalogTable.ToScreen();
        instance.enemy.Hover();
        StartCoroutine(Wait(() =>
        {
            instance.player.FromScreen();
        }, 0.2f));
        StartCoroutine(Wait(() => StartBattle(), 0.4f));
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
