using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(SettingsView))]
public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;  

    private SettingsView _settingsView;

    private void Awake()
    {
        _settingsView = GetComponent<SettingsView>();
    }

    public void SetSoundsVolume()
    {
        var soundsVolume = Mathf.Log10(_settingsView.SoundsSlider.value) * 20;
        _audioMixer.SetFloat("soundsVol", soundsVolume);

        PlayerPresenter.SoundsVolume = _settingsView.SoundsSlider.value;
    }

    public void SetMusicVolume()
    {
        var musicVolume = Mathf.Log10(_settingsView.MusicSlider.value) * 20;
        _audioMixer.SetFloat("musicVol", musicVolume);


        PlayerPresenter.MusicVolume = _settingsView.MusicSlider.value;
    }
}

