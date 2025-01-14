using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public string mainSceneName = "VScene"; 

    
    public void RestartGameButton()
    {
        Debug.Log("Spiel wird neu gestartet...");
        SceneManager.LoadScene(mainSceneName); 
    }

    public void QuitGameButton()
    {
        Debug.Log("Spiel wird beendet...");
        Application.Quit(); 
    }
}
