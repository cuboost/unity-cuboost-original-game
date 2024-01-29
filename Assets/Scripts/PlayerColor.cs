using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    // currentColor = 1
    public Material defaultColor;

    // currentColor = 2
    public Material blueColor;

    // currentColor = 3
    public Material greenColor;

    // currentColor = 4
    public Material pinkColor;

    public int currentColor = 1;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartLevelWithColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentColor++;
            PlayerPrefs.SetInt("PlayerColor", currentColor);
            ChangeColor();
        }
    }

    void StartLevelWithColor()
    {
        currentColor = PlayerPrefs.GetInt("PlayerColor");
        PlayerPrefs.SetInt("PlayerColor", currentColor);
        ChangeColor();
    }

    public void ChangeColor()
    {
        if (currentColor == 5)
        {
            currentColor = 1;
            PlayerPrefs.SetInt("PlayerColor", currentColor);

        }
        if (currentColor == 1)
        {
            rend.material.color = defaultColor.color;
        }
        else if (currentColor == 2)
        {
            rend.material.color = blueColor.color;
        }
        else if (currentColor == 3)
        {
            rend.material.color = greenColor.color;
        }
        else if (currentColor == 4)
        {
            rend.material.color = pinkColor.color;
        }
    }
}
