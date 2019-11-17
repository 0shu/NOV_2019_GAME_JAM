using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ButtonStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ButtonSetting()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
