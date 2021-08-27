using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    [SerializeField] private UiJoystick Joystick;
    
    /*
    
    private void Start()
    {
        PlayerSphere Sphere = PlayerContainer.Instance.PlayerSphere;
        
        Sphere.CastBegin += OnCastBegin;
        Sphere.CastFinish += OnCastFinish;
    }

    private void OnCastBegin() { ChangeState(); }
    private void OnCastFinish() { ChangeState(); }
    
    */

    private void Update()
    {
        Vector3 Direction;

        if (Joystick.Direction != new Vector2())
        {
            Direction = Vector3.Normalize(new Vector3(
                Joystick.Direction.x, 0.0f, Joystick.Direction.y));
        }
        else
        {
            Direction = Vector3.Normalize(new Vector3(
                Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")));
        }
        
        ChangePosition(Direction);
    }
}
