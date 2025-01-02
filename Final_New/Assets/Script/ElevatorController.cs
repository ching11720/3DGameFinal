using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public Animator elevatorAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            elevatorAnimator.SetTrigger("Activate");
        }
    }
}
