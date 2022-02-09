using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    private string toScreen = "ToScreen";
    private string fromScreen = "FromScreen";

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void ToScreen()
    {
        animator.Play(toScreen);
    }

    public void FromScreen()
    {
        animator.Play(fromScreen);
    }
}
