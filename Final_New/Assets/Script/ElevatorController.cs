using System.Collections;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of the elevator movement
    public float minHeight = 0f; // Minimum height (lowest point)
    public float maxHeight = 5f; // Maximum height (highest point)
    private bool isMovingUp = true;

    public Transform elevatorTransform; // Transform of the elevator
    private bool playerOnElevator = false; // To check if the player is on the elevator

    void Start()
    {
        if (elevatorTransform == null)
        {
            elevatorTransform = transform; // Use the object's own transform if not set
        }
    }

    void Update()
    {
        // If the player is on the elevator, let it move
        if (playerOnElevator)
        {
            MoveElevator();
        }
    }

    void MoveElevator()
    {
        if (isMovingUp)
        {
            elevatorTransform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Stop if the elevator reaches the max height
            if (elevatorTransform.position.y >= maxHeight)
            {
                isMovingUp = false;
            }
        }
        else
        {
            elevatorTransform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            // Stop if the elevator reaches the min height
            if (elevatorTransform.position.y <= minHeight)
            {
                isMovingUp = true;
            }
        }
    }


}
