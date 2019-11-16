using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GamePause : MonoBehaviour
{
    public Canvas gamePause;
    public Button resumeButton;
    public static bool GameIsPaused = false;

    void Start()
    {
        gamePause = gamePause.GetComponent<Canvas>();
        resumeButton = resumeButton.GetComponent<Button>();
        gamePause.enabled = false;
        resumeButton.enabled = false;

    }

   void Update()
   {
        if (Input.GetKeyDown(KeyCode.P) && GameIsPaused == false)
        {
            Time.timeScale = 0f;
            GameIsPaused = true;
            gamePause.enabled = true;
            resumeButton.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && GameIsPaused == true)
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            gamePause.enabled = false;
            resumeButton.enabled = false;
        }
   }
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        gamePause.enabled = false;
        resumeButton.enabled = false;
    }
}
