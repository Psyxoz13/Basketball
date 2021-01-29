using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UISound : MonoBehaviour, ISound
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void PlayCertainSound(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
}
