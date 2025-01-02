using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI text
    private int score = 0; // Player's score

    public void AddScore(int value)
    {
        score += value;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("ScoreText is not assigned!");
        }
    }
}
