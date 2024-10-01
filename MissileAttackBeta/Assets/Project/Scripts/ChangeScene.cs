using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string winnerSceneName;
    public string gameOverSceneName;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Column" or "Tank"
        if (collision.gameObject.CompareTag("Column"))
        {
            Invoke("ChangeToGameOverSceneDelayed", 0.5f);
        }
        else if (collision.gameObject.CompareTag("Tank"))
        {
            Invoke("ChangeToWinnerSceneDelayed", 0.5f);
        }
    }

    private void ChangeToGameOverSceneDelayed()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }

    private void ChangeToWinnerSceneDelayed()
    {
        SceneManager.LoadScene(winnerSceneName);
    }
}



