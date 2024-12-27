using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallController : MonoBehaviour
{
   
    private Rigidbody rb;
    public Transform plane; // Assign the plane object here

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
{
    Vector3 gravity = Physics.gravity;
    Vector3 planeNormal = plane.up; // Use the plane's actual tilt
    Vector3 slopeForce = Vector3.ProjectOnPlane(gravity, planeNormal);

    float sensitivityMultiplier = 2.0f; // Amplify slope sensitivity
    rb.AddForce(slopeForce * sensitivityMultiplier, ForceMode.Acceleration);

    Debug.Log("Applied Force: " + slopeForce * sensitivityMultiplier);
}

    }

