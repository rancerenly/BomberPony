using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrintText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textGameObject;

    private string text = "Some text for test feature...";
    private void Start()
    {
        StartCoroutine(TextCoroutine());
    }

    private IEnumerator TextCoroutine()
    {
        foreach (char symbol in text)
        {
            textGameObject.text += symbol;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
