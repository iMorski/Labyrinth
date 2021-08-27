using UnityEngine;

public class PlayerSphereCapture : CharacterSphereCapture
{
    [SerializeField] private UiTouch Touch;

    private void Start()
    {
        Touch.TapBegin += OnTouchTapBegin;
        Touch.TapFinish += OnTouchTapFinish;
    }

    private void OnTouchTapBegin() { Capture(); }
    private void OnTouchTapFinish() { Release(); }
}
