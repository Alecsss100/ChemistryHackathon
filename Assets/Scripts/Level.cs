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
    [SerializeField] Sprite monsterHead;

    private Image gameobjImg;

    public void Awake()
    {
        gameobjImg = GetComponent<Image>();
    }

    public void Start()
    {
        if ((int)levelId <= LvlController.LevelCounter) UnlockLvl();
        else LockLvl();

        if (PlayerPrefs.HasKey("LvlAch" + (int)levelId) ? (PlayerPrefs.GetInt("LvlAch" + (int)levelId) != 0 ? true : false) : false) UnlockAch();
        else LockAch();
    }

    private void UnlockLvl()
    {
        if ((int)levelId == LvlController.LevelCounter) gameobjImg.sprite = monsterHead;
        else gameobjImg.sprite = unlockLvl;
    }

    private void LockLvl()
    {
        gameobjImg.sprite = lockLvl;
    }

    private void UnlockAch()
    {

        if ((int)levelId >= LvlController.LevelCounter) { LockAch(); return; }
        childImage.color = new Color(childImage.color.r, childImage.color.g, childImage.color.b, 1);
        childImage.sprite = LvlController.GetMark(PlayerPrefs.GetInt("LvlAch" + (int)levelId));
        childImage.SetNativeSize();
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
