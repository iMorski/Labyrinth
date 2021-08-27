using UnityEngine;

public class PlayerSpherePush : CharacterSpherePush
{
    [SerializeField] private UiTouch Touch;
    
    private void Start()
    {
        Touch.SwipeByRelease += OnSwipeByRelease;
    }

    private void OnSwipeByRelease(Vector2 Direction)
    {
        Push(new Vector3(Direction.x, 0.0f, Direction.y));
    }
}
