using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GamePause : MonoBehaviour
{
    public Canvas gamePause;
    public Button resumeButton;
    public static bool GameIsPaused = false;
    public AudioSource PauseSFX;


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
            PauseSFX.Play();
        }
        else if (Input.GetKeyDown(KeyCode.P) && GameIsPaused == true)
        {
            Resume();
        }
    }
    public void Resume()
    {
        PauseSFX.Play();
        Time.timeScale = 1f;
        GameIsPaused = false;
        gamePause.enabled = false;
        resumeButton.enabled = false;
    }
}
