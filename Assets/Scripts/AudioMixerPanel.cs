using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMixerPanel : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const string MusicVolume = "MusicVolume";
    private const string EffectsVolume = "EffectsVolume";

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Toggle _checkbox;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _backgroundSlider;
    [SerializeField] private Slider _effectSlider;


    public void ToogleMusic()
    {
        float maxVolume = 0f;
        float minVolume = -80f;

        if (_checkbox.isOn)
        {
            _mixer.audioMixer.SetFloat(MasterVolume, maxVolume);
        }
        else
        {
            _mixer.audioMixer.SetFloat(MasterVolume, minVolume);
        }
    }

    public void ChangeMasterVolume()
    {
        ChangeVolume(_masterSlider.value, MasterVolume);
    }

    public void ChangeBackgroundMusicVolume()
    {
        ChangeVolume(_backgroundSlider.value, MusicVolume);
    }

    public void ChangeSoundEffectsVolume()
    {
        ChangeVolume(_effectSlider.value, EffectsVolume);
    }

    private void ChangeVolume(float volume, string volumeParametr)
    {
        _mixer.audioMixer.SetFloat(volumeParametr, Mathf.Log10(volume) * 20);
    }
}
