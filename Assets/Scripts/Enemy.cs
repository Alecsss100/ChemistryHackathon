using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Element element;

    private Animator animator;

    private string toScreen = "ToScreen";
    private string fromScreen = "FromScreen";
    private string hover = "Hover";

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

    public void Hover()
    {
        animator.Play(hover);
    }

    public void OnMouseEnter()
    {
        MovebleElement.EnemyDetect(true);
    }

    public void OnMouseExit()
    {
        MovebleElement.EnemyDetect(false);
    }
}
