using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    private const string MasterVolumeParametr = "MasterVolume"; // Parameter name for the master volume in the AudioMixer

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _volume;

    private bool _isMuted = false;
    private float _muteVolume = -80f; // Volume level for mute (in decibels)
    private float _previousVolume;

    public void OnButtonClick()
    {
        if (_isMuted == false)
            _audioMixer.GetFloat(MasterVolumeParametr, out _previousVolume);

        float volume = _isMuted ? _previousVolume : _muteVolume; // Toggle between previous volume and -80 dB (mute)
        _audioMixer.SetFloat(MasterVolumeParametr, volume); // Set volume
        _isMuted = !_isMuted; // Toggle mute state
    }

    private float GetSliderValue()
    {
        return _volume.value;
    }
}
