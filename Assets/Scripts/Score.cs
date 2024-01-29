using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Transform player;
    public Text scoreText;

    public static float CurrentScore;

    // Update is called once per frame
    void Update()
    {
        CurrentScore = player.position.z;
        scoreText.text = CurrentScore.ToString("0");
        if (PauseMenu.GameIsPaused == true)
        {
            scoreText.color = Color.white;
        }
        else
        {
            scoreText.color = Color.black;
        }
    }
}
