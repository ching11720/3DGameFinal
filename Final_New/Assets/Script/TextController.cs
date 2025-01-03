using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI text
    private int score; // Player's score
    public CollectManager collectManager;

    private void Start()
    {
        collectManager = FindObjectOfType<CollectManager>();
        score = collectManager.GetStarCount();
        if (scoreText != null)
        {
            scoreText.text = "Remaing Stars: " + score;
        }
        else
        {
            Debug.LogError("ScoreText is not assigned!");
        }
    }

    public void AddScore(int value)
    {
        score -= value;

        if (scoreText != null)
        {
            scoreText.text = "Remaing Stars: " + score;
        }
        else
        {
            Debug.LogError("ScoreText is not assigned!");
        }
    }
}
