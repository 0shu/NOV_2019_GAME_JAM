using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;






public class Collision : MonoBehaviour
{

    public Text Score;
    public int PlayerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        string ObjType = other.gameObject.tag.ToString();

        switch (ObjType)
        {
            case "Death":
                Destroy(other.gameObject);
                Debug.Log("Death!");
                break;
            case "ScoreUp":
                Destroy(other.gameObject);
                PlayerScore += 100;
                Score.text = "Score: " + PlayerScore.ToString();
                Debug.Log("ScoreUp!");
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
