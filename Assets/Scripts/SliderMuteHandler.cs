using UnityEngine;
using UnityEngine.UI;

public class SliderMuteHandler : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void OnMuteButtonPressed(bool muted)
    {
        _slider.interactable = !muted;
    }
}