using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    string sendScore = "";
    public int playerScore = 0;
    public Text scoreText;
    public float exactScore = 0;
    int secondsPassed = 0;
    int bonusPoints = 0;

    void Start()
    {
        scoreText.text = "Score: " + playerScore;
    }
    // Update is called once per frame
    void Update()
    {
        exactScore += Time.deltaTime;
        int secondsPassed = Mathf.FloorToInt(exactScore);
        playerScore = secondsPassed + bonusPoints;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void ScoreUp()
    {
        bonusPoints += 10;
        scoreText.text = "Score: " + playerScore.ToString();

    }
    public string GetScore()
    {
        sendScore = "Your score is " + playerScore.ToString() + " points!";
        return sendScore;
    }
}
