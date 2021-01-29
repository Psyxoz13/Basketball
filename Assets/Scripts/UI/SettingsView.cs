using UnityEngine;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour
{
    public Slider SoundsSlider;
    public Slider MusicSlider;

    private void Start()
    {
        SetSlidersValues();
    }

    private void SetSlidersValues()
    {
        SoundsSlider.value = PlayerView.SoundsVolume;
        MusicSlider.value = PlayerView.MusicVolume;
    }
}
