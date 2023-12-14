using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string gameOverSceneName;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Column" or "Tank"
        if (collision.gameObject.CompareTag("Column") || collision.gameObject.CompareTag("Tank"))
        {
            // Invoke the ChangeSceneDelayed function after a 1-second delay
            Invoke("ChangeSceneDelayed", 0.5f);
        }
    }

    private void ChangeSceneDelayed()
    {
        // Load the game over scene
        SceneManager.LoadScene(gameOverSceneName);
    }
}

