using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject enemy;
    
    [SerializeField]
    private GameObject restart;

    [SerializeField]
    private GameObject gameCon;

    [SerializeField]
    private GameObject win;
    private void FixedUpdate()
    {
        LoadGameOverScreen();
        LoadWinScreen();
    }

    private void LoadGameOverScreen()
    {
        if (player == null)
        {
            restart.SetActive(true);
            gameCon.SetActive(false);
        }
    }

    private void LoadWinScreen()
    {
        if (enemy == null)
        {
            win.SetActive(true);
            gameCon.SetActive(false);
        }
    }

    public void OpenMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
