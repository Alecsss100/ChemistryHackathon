using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovebleElement : MonoBehaviour
{
    [SerializeField] Transform canvas;

    private static MovebleElement instance;
    private RectTransform rectTransform;
    private GameElement currentElement;

    private bool init = false;

    public void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    public static void Init(GameElement element)
    {
        if (instance.init) return;

        instance.currentElement = element;
        instance.currentElement.Hide();

        GameObject gameElement = Instantiate(element, instance.canvas).gameObject;

        instance.rectTransform = gameElement.GetComponent<RectTransform>();
        instance.rectTransform.GetComponent<Image>().SetNativeSize();

        instance.init = true;
    }

    public void Update()
    {
        if (!init) return;

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            init = false;
            currentElement.UnHide();
        }

        Debug.Log(new Vector2(Screen.width / 2, Screen.height / 2));
        rectTransform.localPosition = (Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2);
    }
}
