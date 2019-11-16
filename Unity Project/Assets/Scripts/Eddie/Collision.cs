using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class Collision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        string ObjType = other.gameObject.tag.ToString();

        switch (ObjType)
        {
            case "Death":
                Destroy(other.gameObject);
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
                
            /*case "TurnRateUp":
                Destroy(other.gameObject);
                if (!TurnUp)
                {
                    StartCoroutine("PowerUpTurn");
                }
                break;*/
        }
    }
   /* IEnumerator PowerUpSpeed()
    {
        SpeedUp = true;
        PlayerSpeed *= 1.5f;
        yield return new WaitForSeconds(3.5f);
        PlayerSpeed /= 1.5f;
        SpeedUp = false;

    }
    IEnumerator PowerUpTurn()
    {
        TurnUp = true;
        TurnRate *= 3f;
        yield return new WaitForSeconds(5f);
        TurnRate /= 3f;
        TurnUp = false;
    }*/





}
