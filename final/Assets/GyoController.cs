using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    public float tiltSpeed = 5f;
    public float rollSpeed = 2f;
    public float sensitivity = 2f;
    public float deadZone = 0.1f;

    private void Update()
    {   float tiltX = Input.acceleration.x; // Left/right tilt
    float tiltY = Input.acceleration.y; // Forward/backward tilt

    float tiltMultiplier = 15f; // Increase multiplier for steeper tilt
    transform.rotation = Quaternion.Euler(tiltY * tiltMultiplier, 0, -tiltX * tiltMultiplier);

    }
}
