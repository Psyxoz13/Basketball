using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BasketballNetSound : MonoBehaviour
{
    [SerializeField] private float _audioVolumeMultiplier = 0.0015f;
    [SerializeField] private float _minBallSpeed = 5f;
    [SerializeField] private float _minBallIgnoredYVelocity = 0f;
    [SerializeField] private float _maxBallIgnoredYVelocity = 5f;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var attachedRigidBody = other.attachedRigidbody;

        if (IsIgnored(attachedRigidBody))
            return;

        if (other.CompareTag("Ball"))
        {
            _audioSource.PlayOneShot(
                _audioSource.clip,
                Volume.GetVolumeScaleFromSpeed(
                    attachedRigidBody,
                    _audioVolumeMultiplier,
                    _minBallSpeed));
        }
    }

    private bool IsIgnored(Rigidbody attachedRigidBody)
    {
        if (attachedRigidBody.velocity.y > _minBallIgnoredYVelocity 
            && attachedRigidBody.velocity.y < _maxBallIgnoredYVelocity )
        {
            return true;
        }

        return false;
    }
}
