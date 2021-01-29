using System.Collections.Generic;
using UnityEngine;

public class AudioSourcesPool : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourcesTemplate;
    [SerializeField] private int _poolSize = 5;

    private readonly Queue<AudioSource> _audioSourcesQueue = new Queue<AudioSource>();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            _audioSourcesQueue.Enqueue(CreateAudioSource());
        }
    }

    public AudioSource GetAudioSource()
    {
        var audioSource = _audioSourcesQueue.Dequeue();
        _audioSourcesQueue.Enqueue(audioSource);

        return audioSource;
    }

    private AudioSource CreateAudioSource()
    {
        var newAudioSource = Instantiate(_audioSourcesTemplate, transform);

        return newAudioSource;
    }
}
