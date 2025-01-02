using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // Assign the ball prefab here
    public Transform spawnArea; // Assign a large cube or plane to define the spawn area
    public float spawnInterval = 2f; // Time between spawns
    public int maxBalls = 10; // Max balls allowed in the scene

    private int currentBallCount = 0;

    void Start()
    {
        InvokeRepeating(nameof(SpawnBall), spawnInterval, spawnInterval);
    }

    void SpawnBall()
    {
        if (currentBallCount >= maxBalls) return;

        // Calculate random spawn position within spawn area
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2),
            spawnArea.position.y + 1f,
            Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2, spawnArea.position.z + spawnArea.localScale.z / 2)
        );

        // Spawn the ball
        Instantiate(ballPrefab, randomPosition, Quaternion.identity);
        currentBallCount++;
    }
}
