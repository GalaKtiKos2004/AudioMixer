using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MusicMuter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _masterSlider;

    private Toggle _checkbox;

    private void Awake()
    {
        _checkbox = GetComponent<Toggle>();
    }

    public void ToogleMusic()
    {
        float minVolume = -80f;

        if (_checkbox.isOn)
        {
            _mixer.audioMixer.SetFloat(_mixer.name, Mathf.Log10(_masterSlider.value) * 20);
        }
        else
        {
            _mixer.audioMixer.SetFloat(_mixer.name, minVolume);
        }
    }
}
