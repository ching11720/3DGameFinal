using UnityEngine;

public class StarController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed at which the star rotates
    public float floatSpeed = 0.5f; // Speed at which the star floats up and down
    public float floatAmplitude = 0.5f; // Amplitude of the floating effect

    private Vector3 startPosition;

    void Start()
    {
        // Save the starting position of the star
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the star
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);

        // Make the star float up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
