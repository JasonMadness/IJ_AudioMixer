using System;
using UnityEngine;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const float MuteVolume = -80f;

    [SerializeField] private AudioMixer _audioMixer;

    private bool _isMuted;
    private float _previousVolume;

    public event Action<bool> _pressed;

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            _audioMixer.GetFloat(MasterVolume, out _previousVolume);
            _audioMixer.SetFloat(MasterVolume, MuteVolume);
        }
        else
        {
            _audioMixer.SetFloat(MasterVolume, _previousVolume);
        }

        _pressed?.Invoke(_isMuted);
    }
}