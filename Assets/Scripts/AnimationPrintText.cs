using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPrintText : MonoBehaviour
{
    //public Text uiText;
    //public float spawnTime = 0.1f;

    public void StartAnimation(string text, Text uiText, float spawnTime)
    {
        StartCoroutine(TextCoroutine(text, uiText, spawnTime));
    }
    IEnumerator TextCoroutine(string text, Text uiText, float spawnTime)
    {
        uiText.text = "";
        foreach (char c in text)
        {
            uiText.text += c.ToString();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
