using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubscriber : MonoBehaviour
{
    [SerializeField] private MuteButton _muteButton;
    [SerializeField] private SliderMuteHandler[] _muteHandlers;

    private void OnEnable()
    {
        foreach (var handler in _muteHandlers)
        {
            _muteButton._pressed += handler.OnMuteButtonPressed;
        }
    }

    private void OnDisable()
    {
        foreach (var handler in _muteHandlers)
        {
            _muteButton._pressed -= handler.OnMuteButtonPressed;
        }
    }
}
