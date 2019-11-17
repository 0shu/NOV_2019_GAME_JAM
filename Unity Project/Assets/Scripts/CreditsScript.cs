using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public string ReturnScene;
    public AudioSource Sound;
    AudioClip SoundClip;

    void Start()
    {
        SoundClip = Sound.clip;
    }


    public void ButtonReturn()
    {
        StartCoroutine("ButtonClicked");

    }




    private IEnumerator ButtonClicked()
    {
        Sound.Play();

        yield return new WaitForSeconds(SoundClip.length);
        SceneManager.LoadScene(ReturnScene);
    }
}


