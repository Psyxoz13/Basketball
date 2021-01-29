using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public List<AudioClip> Playlist = new List<AudioClip>();

    [SerializeField] private AudioClip _cassette—hangeSound;

    [Header("UI")]
    [SerializeField] private Text _trackName;
    [SerializeField] private ImageSwitch _playButtonImageSwitch;

    private ObjectSelectionList<AudioClip> _selectionPlaylist;

    private AudioSource _audioSource;
    private bool _isPaused = false;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _selectionPlaylist = Playlist.ToSelectionList();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        SetTrack(_selectionPlaylist[0]);
    }

    private void Update()
    {
        if (_audioSource.isPlaying == false 
            && _isPaused == false)
        {
            NextTrack();
        }
    }

    public void NextTrack()
    {
        SetTrack(_selectionPlaylist.Next());
    }

    public void PreviousTrack()
    {
        SetTrack(_selectionPlaylist.Previous());
    }

    public void Pause()
    {
        if (_isPaused)
        {
            _isPaused = false;
            _audioSource.Play();
        }
        else
        {
            _isPaused = true;
            _audioSource.Pause();
        }
        _playButtonImageSwitch.NextImage();
    }

    private void SetTrack(AudioClip clip)
    {
        _audioSource.PlayOneShot(_cassette—hangeSound);

        _audioSource.clip = clip;

        _trackName.text = clip.name;
        _audioSource.PlayDelayed(_cassette—hangeSound.length);
    }
}
