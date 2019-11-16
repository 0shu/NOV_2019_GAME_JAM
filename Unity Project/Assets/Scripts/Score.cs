using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public int playerScore = 0;
    public Text scoreText;
    public float exactScore = 0;

    void Start()
    {
        scoreText.text = "Score: " + playerScore;
    }
    // Update is called once per frame
    void Update()
    {
        exactScore += Time.deltaTime;
        playerScore = Mathf.FloorToInt(exactScore);
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public int GetScore()
    {
        return playerScore;
    }
}
