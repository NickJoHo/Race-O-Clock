using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        // Check every frame if the player presses the 'R' key
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        // 1. IMPORTANT: Set time back to 1, or the new game will be frozen!
        Time.timeScale = 1f;

        // 2. Reload the scene you are currently in
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("Game Restarted via R key");
    }
}