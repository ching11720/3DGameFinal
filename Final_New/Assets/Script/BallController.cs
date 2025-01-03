using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BallController : MonoBehaviour
{
   
    private Rigidbody rb;
    public Transform plane; // Assign the plane object here
    public int score = 0; // Player's score
    public AudioSource starSound; // Reference to the AudioSource component
    public GameManager gameManager; // Reference to the timer script
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        
    }


    void FixedUpdate(){
        Vector3 gravity = Physics.gravity;
        Vector3 planeNormal = plane.up; // Use the plane's actual tilt
        Vector3 slopeForce = Vector3.ProjectOnPlane(gravity, planeNormal);

        float sensitivityMultiplier = 2.0f; // Amplify slope sensitivity
        rb.AddForce(slopeForce * sensitivityMultiplier, ForceMode.Acceleration);

        Debug.Log("Applied Force: " + slopeForce * sensitivityMultiplier);
    }
  void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            Debug.Log("Collected a Star!");

            // Notify the TextController to update the score
            FindObjectOfType<TextController>().AddScore(1);

            // Destroy the star
            Destroy(other.gameObject);
            if (starSound != null){
                starSound.Play();
            }
        }

        if (gameManager != null)
            {
                gameManager.CheckWinCondition(score);
            }
    }
}


       

