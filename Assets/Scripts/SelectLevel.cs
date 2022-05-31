using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SelectLevel : MonoBehaviour
{
    public void Select(int level)
    {
        SceneManager.LoadScene(level);
    }
}
