using UnityEngine;

public class BallReturn : MonoBehaviour
{
    [SerializeField] private Transform _returnPoint;
    [SerializeField] private Vector3 _startVelocity;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.attachedRigidbody.position = _returnPoint.position;
            other.attachedRigidbody.velocity = _startVelocity;
        }
    }
}
