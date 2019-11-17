using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioSource PlayGame;
    AudioClip PlayGameClip;

    public AudioSource Credits;
    AudioClip CreditsClip;

    public AudioSource Exit;
    AudioClip ExitClip;

    public string PlayScene;
    public string CreditsScene;

    void Start()
    {
        
        PlayGameClip = PlayGame.clip;
        CreditsClip = Credits.clip;
        ExitClip = Exit.clip;
    }



    public void ButtonStart()
    {
        StartCoroutine("StartButtonClicked");
    }

    public void ButtonSetting()
    {
        StartCoroutine("CreditsButtonClicked");
    }

    public void ButtonQuit()
    {
        StartCoroutine("QuitButtonClicked");

    }


    private IEnumerator QuitButtonClicked()
    {
        Exit.Play();

        yield return new WaitForSeconds(ExitClip.length);
        Application.Quit();
    }

    private IEnumerator StartButtonClicked()
    {
        PlayGame.Play();

        yield return new WaitForSeconds(PlayGameClip.length);
        SceneManager.LoadScene(PlayScene);

    }

    private IEnumerator CreditsButtonClicked()
    {
        Credits.Play();

        yield return new WaitForSeconds(CreditsClip.length);
        SceneManager.LoadScene(CreditsScene);

    }

    // yield return new WaitForSeconds(2f);


}
