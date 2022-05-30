using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}