using UnityEngine;

public class FlightCurrectionZone : MonoBehaviour
{
    [Header("Flight Correction")]
    [SerializeField] private Transform _flightCorrectionTarget;
    [SerializeField] private Vector3 _flightCorrectionVector;
    [SerializeField] private Mode _flightCorrectionMode;

    public enum Mode
    { 
        Forward,
        Backward,
        Upward,
        Downward,
        Both
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CheckMode(other.attachedRigidbody);
            AdjustFlight(other.attachedRigidbody);
        }
    }

    private void CheckMode(Rigidbody rigidBody)
    {
        switch(_flightCorrectionMode)
        {
            case Mode.Forward:
                if (rigidBody.velocity.z > 0)
                    AdjustFlight(rigidBody);
                break;
            case Mode.Backward:
                if (rigidBody.velocity.z < 0)
                    AdjustFlight(rigidBody);
                break;
            case Mode.Downward:
                if (rigidBody.velocity.y < 0)
                    AdjustFlight(rigidBody);
                break;
            case Mode.Upward:
                if (rigidBody.velocity.y > 0)
                    AdjustFlight(rigidBody);
                break;
            case Mode.Both:
                AdjustFlight(rigidBody);
                break;
        }
    }

    private void AdjustFlight(Rigidbody rigidBody)
    {
        var direction = (_flightCorrectionTarget.position - rigidBody.position).normalized;
        rigidBody.velocity += new Vector3(
            direction.x * _flightCorrectionVector.x,
            direction.y * _flightCorrectionVector.y,
            direction.z * _flightCorrectionVector.z)
            * Time.deltaTime;
    }
}
