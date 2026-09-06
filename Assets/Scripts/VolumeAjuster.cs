using UnityEngine;
using UnityEngine.Audio;

public class VolumeAjuster : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _exposedParameterName;

    private const float MinVolumeInDecibels = -80f;
    private const float MinLinearVolume = 0.0001f;

    public void SetVolume(float linearValue)
    {
        float volumeInDecibels;

        if (linearValue > MinLinearVolume)
            volumeInDecibels = Mathf.Log10(linearValue) * 20f;
        else
            volumeInDecibels = MinVolumeInDecibels;

        _audioMixer.SetFloat(_exposedParameterName, volumeInDecibels);
    }
}