using UnityEngine;

public class EndFirstTimePlaying : MonoBehaviour
{
    public GameManager GameManager;

    void OnTriggerEnter()
    {
        CompleteFirstTimePlaying();
    }

    public void CompleteFirstTimePlaying()
    {
        PlayerPrefs.SetString("FirstTimePlaying", "No");
        GameManager.CompleteLevel();
    }
}