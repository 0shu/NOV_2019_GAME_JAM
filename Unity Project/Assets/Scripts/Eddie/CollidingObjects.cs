using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class CollidingObjects : MonoBehaviour
{
    public AudioSource[] DeathSFX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            int randomSFX = Random.Range(0, 2);
            DeathSFX[randomSFX].Play();
            Debug.Log("Playing SFX " + randomSFX);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DeathSFX[0].Play();
            Debug.Log("Playing SFX 0");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            DeathSFX[1].Play();
            Debug.Log("Playing SFX 1");
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        string ObjType = other.gameObject.tag.ToString();

        switch (ObjType)
        {
            case "Death":
                Destroy(other.gameObject);
                DeathSFX[0].Play();
                Debug.Log("Death!");
                GetComponent<GameOverLora>().OnDeath();

                break;
            case "ScoreUp":
                Destroy(other.gameObject);
                GetComponent<Score>().ScoreUp();

                break;
            case "Powerup":
                Destroy(other.gameObject);
                Debug.Log("Powerup!");
                break;
                
          }
    }
  
}
