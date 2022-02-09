using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovebleElement : MonoBehaviour
{
    [SerializeField] Transform canvas;
    private static MovebleElement instance;
    private RectTransform rectTransform;
    private static Vector2 deltaDistance;
    private bool init = false;
    public void Awake()
    {
        if (instance) Destroy(gameObject);
        else instance = this;
    }

    public static void Init(GameElement element)
    {
        if (instance.init) return;
        GameObject gameElement = Instantiate(element, instance.canvas).gameObject;
        deltaDistance = (Vector2)Input.mousePosition;
        instance.rectTransform = gameElement.GetComponent<RectTransform>();
        instance.rectTransform.GetComponent<Image>().SetNativeSize();
        instance.init = true;
    }

    public void Update()
    {
        if (!init) return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            init = false;
//Destroy(rectTransform.gameObject);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            init = false;
            Destroy(rectTransform.gameObject);
        }

        Debug.Log(new Vector2(Screen.width / 2, Screen.height / 2));
        rectTransform.localPosition = (Vector2)Input.mousePosition - new Vector2(Screen.width / 2, Screen.height / 2);
    }
}
