using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    // public float timeLimit = 60f; // Total time in seconds
    private float timeRemaining;
    public TextMeshProUGUI timerText; // Reference to the timer UI
    // public int requiredStars = 0; // Number of stars required to win

    private bool isGameOver = false;

    void Start()
    {
        // timeRemaining = timeLimit;
        timeRemaining = 0f;
        UpdateTimerUI();
    }

    void Update()
    {
        // if (isGameOver) return;

        // Countdown the timer
        timeRemaining += Time.deltaTime;

        // Check if time has run out
        // if (timeRemaining <= 0)
        // {
        //     timeRemaining = 0;
        //     GameOver(false); // Time's up, game over
        // }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public float GetTime()
    {
        return timeRemaining;
    }

    // public void CheckWinCondition(int currentScore)
    // {
    //     if (currentScore == requiredStars)
    //     {
    //         GameOver(true); // Player wins
    //     }
    // }

    // void GameOver(bool hasWon)
    // {
    //     isGameOver = true;

    //     if (hasWon)
    //     {
    //         Debug.Log("You Win! Collected all stars.");
    //         // Show a "You Win" screen or trigger the next level
    //     }
    //     else
    //     {
    //         Debug.Log("Game Over! Time ran out.");
    //         // Show a "Game Over" screen or restart the game
    //     }
    // }
}
