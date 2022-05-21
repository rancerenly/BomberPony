using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void PlayPressed()
    {
        SceneManager.LoadScene("TestController");
    }
    
    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
