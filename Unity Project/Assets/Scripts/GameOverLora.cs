using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverLora : MonoBehaviour
{
    public Canvas gameOver;
    public Button playAgainButton;
    public Button backButton;
    public Text scoreText;

    // Initialization
    void Start()
    {
        gameOver = gameOver.GetComponent<Canvas>();
        playAgainButton = playAgainButton.GetComponent<Button>();
        backButton = backButton.GetComponent<Button>();     
        gameOver.enabled = false;
        playAgainButton.enabled = false;
        backButton.enabled = false;
        scoreText.enabled = false;
    }

    public void OnDeath()
    {
        Time.timeScale = 0f;
        gameOver.enabled = true;
        playAgainButton.enabled = true;
        backButton.enabled = true;
        scoreText.text = GetComponent<Score>().GetScore();
        scoreText.enabled = true;
    }

    // Play again
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene"); // FIX NAME OF THE SCENE
    }

    // Back to main menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu"); // FIX NAME OF SCENE
    }
}