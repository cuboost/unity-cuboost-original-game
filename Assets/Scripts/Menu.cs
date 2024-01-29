using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject FirstTimePlayingPopUp;
    public GameObject SettingsPopUp;
    public LoadNewLevel loadNewLevel;

    public void StartGame()
    {
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            if (PlayerPrefs.GetString("FirstTimePlaying") == "No")
            {
                FirstTimePlayingPopUp.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetString("FirstTimePlaying", "Yes");
                loadNewLevel.currentLevel = 1;
                loadNewLevel.StartNewLevel();
            }
        }
        else
        {
            loadNewLevel.currentLevel = PlayerPrefs.GetInt("Level");
            loadNewLevel.StartNewLevel();
        }
    }

    // Pop-up
    public void LearnHowToPlayPopUpYes()
    {
        FirstTimePlayingPopUp.SetActive(false);
        PlayerPrefs.SetString("FirstTimePlaying", "No");
        loadNewLevel.currentLevel = 2;
        loadNewLevel.StartNewLevel();
    }

    public void LearnHowToPlayPopUpNo()
    {
        FirstTimePlayingPopUp.SetActive(false);
        PlayerPrefs.SetString("FirstTimePlaying", "Yes");
        loadNewLevel.currentLevel = 1;
        loadNewLevel.StartNewLevel();
    }

    public void Settings()
    {
        Debug.Log("Opening Settings");
        SettingsPopUp.SetActive(true);
    }

    public void CloseSettings()
    {
        Debug.Log("Closing Settings");
        SettingsPopUp.SetActive(false);
    }

    // Color changed in settings
    public void PlayerColorRed()
    {
        FindObjectOfType<PlayerColor>().currentColor = 1;
        SavePlayerColor();
    }
    public void PlayerColorBlue()
    {
        FindObjectOfType<PlayerColor>().currentColor = 2;
        SavePlayerColor();
    }
    public void PlayerColorGreen()
    {
        FindObjectOfType<PlayerColor>().currentColor = 3;
        SavePlayerColor();
    }
    public void PlayerColorPink()
    {
        FindObjectOfType<PlayerColor>().currentColor = 4;
        SavePlayerColor();
    }

    public void SavePlayerColor()
    {
        PlayerPrefs.SetInt("PlayerColor", FindObjectOfType<PlayerColor>().currentColor);
        Debug.Log("Player Color Saved...");
    }
}
