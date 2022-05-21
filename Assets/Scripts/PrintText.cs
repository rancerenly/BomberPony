using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrintText : MonoBehaviour
{
    public TextMeshProUGUI textGameObject;
    public string text = "Some text for test feature...";
    void Start()
    {
        StartCoroutine(TextCoroutine());
    }

    IEnumerator TextCoroutine()
    {
        foreach (char symbol in text)
        {
            textGameObject.text += symbol;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
