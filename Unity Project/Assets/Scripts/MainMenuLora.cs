using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuLora : MonoBehaviour
{
    public Button playButton;
    public Button creditsButton;
    public Button exitButton;

    // Initialization
    void Start()
    {
        playButton = playButton.GetComponent<Button>();
        creditsButton = creditsButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // FIX NAME OF THE SCENE
    }


    public void CreditsPressed()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
