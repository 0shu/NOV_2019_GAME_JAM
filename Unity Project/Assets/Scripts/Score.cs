using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int playerScore = 0;
    public Text scoreText;

    void Start()
    {
        scoreText.text = "Score: " + playerScore;
    }
    // Update is called once per frame
    void Update()
    {
        playerScore++;
        scoreText.text = "Score: " + playerScore.ToString();

    }
}
