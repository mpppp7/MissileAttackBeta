using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public string mainSceneName;

    // This function is called when the restart button is clicked or input trigger happens
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Load the main scene
        SceneManager.LoadScene(mainSceneName);
    }
}

