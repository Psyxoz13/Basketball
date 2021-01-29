using System.Collections;
using UnityEngine;

public class DynamicImpactSound : MonoBehaviour
{
    [SerializeField] private AudioSourcesPool _audioSourcePool;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _audioVolumeMultiplier = 0.0015f;

    private const float DelayAfterPlayback = 0.2f;

    private static bool _canPlay = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (_canPlay)
        {
            var audioSource = _audioSourcePool.GetAudioSource();

            audioSource.transform.position = collision.GetContact(0).point;
            audioSource.PlayOneShot(_audioClip, Volume.GetVolumeScaleFromSpeed(collision.rigidbody, _audioVolumeMultiplier));

            StartCoroutine(GetDelay());
        }
    }

    private static IEnumerator GetDelay()
    {
        _canPlay = false;
        yield return new WaitForSeconds(DelayAfterPlayback);
        _canPlay = true;
    }
}
