using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public GameObject completeAllLevelsUI;


    public void CompleteLevel()
    {
        Debug.Log("Complete Level Animation");
        Time.timeScale = 0.2f;
        if (PlayerPrefs.GetInt("Level") == 5)
        {
            completeAllLevelsUI.SetActive(true);
            Debug.Log("All levels completed!");
        }
        else
        {
            completeLevelUI.SetActive(true);
        }
    }

    public void SaveLevel(int currentLevel)
    {
        Debug.Log("Level Saving");
        PlayerPrefs.SetInt("Level", currentLevel);
        Debug.Log("Saved that the current level is " + (PlayerPrefs.GetInt("Level") - 1));
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Restart Game
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

}
