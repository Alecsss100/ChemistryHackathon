using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Animator healthBarAnimator;
    [SerializeField] Image mainSprite;
    [SerializeField] Image secondSprite;

    [Header("Textures")]
    [SerializeField] Sprite greenSB;
    [SerializeField] Sprite yellowSB;
    [SerializeField] Sprite redSB;


    private int gameHp = 3;
    public int HP
    {
        get
        {
            return gameHp;
        }
        private set
        {
            if (value >= 0 && value <= 3)
                gameHp = value;
        }
    }

    public void Awake()
    {
        SetVisualHealth();
    }

    public void HpDown()
    {
        HP -= 1;
        HpAnimation();
        if (HP == 0) GameController.Lose();
    }

    public void HpAnimation()
    {
        healthBarAnimator.Play("Trans"+HP,-1,0f);
    }

    public void SetVisualHealth()
    {
        switch (HP)
        {
            case 3:
                mainSprite.sprite = greenSB;
                secondSprite.sprite = yellowSB;
                break;
            case 2:
                mainSprite.sprite = greenSB;
                secondSprite.sprite = yellowSB;
                break;
            case 1:
                mainSprite.sprite = yellowSB;
                secondSprite.sprite = redSB;
                break;
            case 0:
                mainSprite.sprite = redSB;
                secondSprite.sprite = null;
                break;
        }

        mainSprite.color = new Color(mainSprite.color.r, mainSprite.color.g, mainSprite.color.b,1);
        secondSprite.color = new Color(secondSprite.color.r, secondSprite.color.g, secondSprite.color.b,0);
    }
}
