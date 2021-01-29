using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public Rigidbody BallRigidbody { get; private set; }

    public bool IsTaken { get; set; } = false;
    public bool CanTaken { get; set; } = false;

    private void Awake()
    {
        BallRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallSelectionArea"))
            CanTaken = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BallSelectionArea"))
            CanTaken = false;
    }
}
