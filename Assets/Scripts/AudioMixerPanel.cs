using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class AudioMixerPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Toggle _checkbox;

    private Slider _slider;

    private string _volumeParametr;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _volumeParametr = _mixer.name;
    }

    public void ChangeVolume()
    {
        if (_checkbox.isOn)
        {
            _mixer.audioMixer.SetFloat(_volumeParametr, Mathf.Log10(_slider.value) * 20);
        }
    }
}
