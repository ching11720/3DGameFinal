using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CollectManager collectManager;
    public GameObject fallDownPanel;
    public GameObject winPanel;
    public GameObject SpawnPoint;
    public GameObject ball;
    public Button nextLevelButton;
    public Camera mainCamera;
    public TextMeshProUGUI GameOverText;
    public GameTimer gameTimer;
    public TextMeshProUGUI fallDownText;

    // private float cameraMoveSpeed = 5f;
    private bool isWin = false;
    private int RespawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        collectManager = FindObjectOfType<CollectManager>();
        gameTimer = FindObjectOfType<GameTimer>();
        fallDownPanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);
        fallDownText.gameObject.SetActive(false);
        if (nextLevelButton != null)
        {
            nextLevelButton.gameObject.SetActive(false);
        }
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false);
        }
        RespawnCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current Star Count: " + collectManager.GetStarCount());
        CheckWinCondition(collectManager.GetStarCount());
    }

    public void CheckWinCondition(int score)
    {
        if (score == 0 && !isWin)
        {
            isWin = true;
            if (nextLevelButton != null)
            {
                nextLevelButton.gameObject.SetActive(true);
            }
            winPanel.gameObject.SetActive(true);
            if (GameOverText != null)
            {
                GameOver();
            }
        }
    }

    public void FallDown()
    {
        fallDownPanel.gameObject.SetActive(true);
        fallDownText.gameObject.SetActive(true);
    }

    public void StartSpawnBall()
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        Destroy(ball);
        ball = Instantiate(ball, SpawnPoint.transform.position, Quaternion.identity);
        SmoothCameraFollow cameraFollowScript = mainCamera.GetComponent<SmoothCameraFollow>();
        if (cameraFollowScript != null)
        {
            cameraFollowScript.target = ball.transform;
        }

        // Vector3 startPosition = mainCamera.transform.position;
        // Vector3 targetPosition = SpawnPoint.transform.position + new Vector3(0, 9, -17f);

        // float journeyLength = Vector3.Distance(startPosition, targetPosition);
        // float startTime = Time.time;

        // while (Time.time - startTime < journeyLength / cameraMoveSpeed)
        // {
        //     float distanceCovered = (Time.time - startTime) * cameraMoveSpeed;
        //     float fractionOfJourney = distanceCovered / journeyLength;

        //     mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
        //     yield return null;
        // }

        // mainCamera.transform.position = targetPosition;
        fallDownPanel.gameObject.SetActive(false);
        RespawnCount++;
        yield return null;
    }

    private void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = "You Win!\n Respawn Count: " + RespawnCount + "\n Spend Time: " + gameTimer.GetTime();
    }
}
