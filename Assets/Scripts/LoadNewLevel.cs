using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public int currentLevel = 1;
    public GameManager gameManager;
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        currentLevel = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Starting new level");
        StartNewLevel();
    }

    public void StartNewLevel()
    {
        Debug.Log("Loading level " + (currentLevel - 1));
        SceneManager.LoadScene(currentLevel);
        gameManager.SaveLevel(currentLevel);
    }
}
