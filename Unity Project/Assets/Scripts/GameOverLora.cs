using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverLora : MonoBehaviour
{
    public Canvas gameOver;
    public Button playAgainButton;
    public Button backButton;

    // Initialization
    void Start()
    {
        gameOver = gameOver.GetComponent<Canvas>();
        playAgainButton = playAgainButton.GetComponent<Button>();
        backButton = backButton.GetComponent<Button>();
        gameOver.enabled = false;
        playAgainButton.enabled = false;
        backButton.enabled = false;
    }

    public void OnDeath()
    {
        gameOver.enabled = true;
        playAgainButton.enabled = true;
        backButton.enabled = true;
    }

    // Play again
    public void PlayAgain()
    {
        SceneManager.LoadScene("Eddie2"); // FIX NAME OF THE SCENE
    }

    // Back to main menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("LORA"); // FIX NAME OF SCENE
    }
}