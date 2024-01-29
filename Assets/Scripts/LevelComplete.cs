using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public LoadNewLevel loadNewLevel;
    public Text levelNumber;
    public void LevelFinished()
    {
        Debug.Log("Level Finished");
        loadNewLevel.LoadNextLevel();
    }
    public void SetLevelText()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            levelNumber.text = "Wow";
        }
        else
        {
            levelNumber.text = SceneManager.GetActiveScene().buildIndex.ToString();
        }
    }
}
