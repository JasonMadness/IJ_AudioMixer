using UnityEngine;
using UnityEngine.Audio;

public class VolumeAjuster : MonoBehaviour
{
    private const float MinVolumeInDecibels = -80f;
    private const float MinLinearVolume = 0.0001f;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _exposedParameterName;

    public void SetVolume(float sliderValue)
    {
        float volumeInDecibels;

        if (sliderValue > MinLinearVolume)
            volumeInDecibels = Mathf.Log10(sliderValue) * 20f;
        else
            volumeInDecibels = MinVolumeInDecibels;

        _audioMixer.SetFloat(_exposedParameterName, volumeInDecibels);
    }
}