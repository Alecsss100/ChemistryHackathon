using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Level : MonoBehaviour
{
    [Header("Хранилище")]
    [SerializeField] LevelEnum.Level levelId;
    [SerializeField] Image childImage;

    [Header("Текстуры")]
    [SerializeField] Sprite lockLvl;
    [SerializeField] Sprite unlockLvl;

    private Image gameobjImg;

    private void Awake()
    {
        gameobjImg = GetComponent<Image>();
    }

    private void Start()
    {
        Debug.Log("Дописать для бг чтоб серым становился");
        if ((int)levelId <= LvlController.LevelCounter) UnlockLvl();
        else LockLvl();

        if (PlayerPrefs.HasKey("LvlAch" + (int)levelId) ? (PlayerPrefs.GetInt("LvlAch" + (int)levelId) == 1 ? true : false) : false) UnlockAch();
        else LockAch();
    }

    private void UnlockLvl()
    {
        gameobjImg.sprite = unlockLvl;
    }

    private void LockLvl()
    {
        gameobjImg.sprite = lockLvl;
    }

    private void UnlockAch()
    {
        childImage.color = new Color(childImage.color.r, childImage.color.g, childImage.color.b, 1);
    }

    private void LockAch()
    {
        childImage.color = new Color(childImage.color.r, childImage.color.g, childImage.color.b, 0);
    }

    public int GetLvlId()
    {
        return (int)levelId;
    }
}
