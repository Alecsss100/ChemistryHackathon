using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] ElementsConnection resultConnection;

    [SerializeField] Inventory inventory;

    [SerializeField] DigalogTable digalogTable;
    [SerializeField] HealthBar healthBar;
    [SerializeField] Discription discription;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;

    [Header("Transition")]
    [SerializeField] Animator animatorTransition;

    [Header("Screens")]
    [SerializeField] Animator achScreen;
    [SerializeField] Animator winScreen;
    [SerializeField] WinScreen winScreenScript;

    [Header("Ach Checker")]
    [SerializeField] Achievement achieve;

    private List<Element> combinedElements;
    private List<Element> combo = new List<Element>();

    private System.Action action = () => instance.EndDialog();

    private static GameController instance;

    public void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;

        combinedElements = resultConnection.GetCombElements();
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameElement.UnHighLightEl();
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
        StartCoroutine(Wait(() => NextCharacter(), 0.75f));
    }

    public static int GetHp()
    {
        return instance.healthBar.HP;
    }

    public bool AddElementCombo(Element element)
    {
        foreach (var item in combinedElements)
        {
            if (item.nameChemestry == element.nameChemestry)
            {
                for (int i = 0; i < combinedElements.Count; i++)
                    if (combinedElements[i].nameChemestry == element.nameChemestry)
                    {
                        combinedElements.RemoveAt(i);
                        return true;
                    }
            }
        }
        return false;
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
        Debug.Log("Вы победили");
        instance.winScreenScript.SwitchStone();
        LvlController.LvlUp();
        if (instance.achieve.Check())
        {
            GetAchive();
            instance.achScreen.Play("ToScreen");
        }
        else instance.winScreen.Play("ToScreen");
    }

    public static void Lose()
    {
        Debug.Log("Вы проиграли");
        Transition.SwitchLevelUp();
        instance.animatorTransition.Play("SwitchLevelBack");
    }

    public static void GetAchive()
    {
        PlayerPrefs.SetInt("LvlAch" + LvlController.GetChoosenLvl(), instance.healthBar.HP);
    }

    public static void PlaceTextInDiscription(string text)
    {
        instance.discription.PlaceText(text);
    }

    public static void ShowDiscriptionText()
    {
        instance.discription.ShowText();
    }

    public static void DisableDiscriptionText()
    {
        instance.discription.HideText();
    }

    public static void AddElement(Element element)
    {
        Debug.Log("Добавлен " + element.nameChemestry);
        if (!instance.AddElementCombo(element)) instance.healthBar.HpDown();
        else if (instance.combinedElements.Count == 0) Win();
    }

    IEnumerator Wait(System.Action action, float seconds = 1)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
