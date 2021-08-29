using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float SmoothTime;
    
    private Rigidbody Rigidbody;
    private Animator Animator;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
    }
    
    private bool OnCast;

    public void ChangeState()
    {
        if (!OnCast) Animator.CrossFade("Movement-Cast", SmoothTime);
        else Animator.CrossFade("Movement-Free", SmoothTime);
        
        OnCast = !OnCast;
    }

    private Vector3 Position;

    public void ChangePosition(Vector3 Direction)
    {
        if (Direction != new Vector3())
        {
            Position = Vector3.Normalize(new Vector3(
                Direction.x, 0.0f, Direction.z));

            SmoothRotation();
            SmoothAnimatorSpeed(1.0f);
        }
        else
        {
            SmoothPosition();
            SmoothAnimatorSpeed(0.0f);
        }

        Rigidbody.velocity = Position * SmoothSpeed();
    }
    
    private Vector3 PositionVelocity;
    
    private void SmoothPosition()
    {
        if (Position != new Vector3()) Position = 
            Vector3.SmoothDamp(Position, new Vector3(),
                ref PositionVelocity, SmoothTime);
    }

    private Vector3 RotationDirection;
    private Vector3 RotationVelocity;

    private void SmoothRotation()
    {
        if (RotationDirection != Position) RotationDirection = Vector3.SmoothDamp(
            RotationDirection, Position, ref RotationVelocity, SmoothTime);
        
        transform.rotation = Quaternion.LookRotation(RotationDirection);
    }
    
    private float AnimatorSpeed;
    private float AnimatorVelocity;

    private void SmoothAnimatorSpeed(float Value)
    {
        if (AnimatorSpeed != Value) AnimatorSpeed = Mathf.SmoothDamp(
            AnimatorSpeed, Value, ref AnimatorVelocity, SmoothTime);
        
        Animator.SetFloat("Speed", AnimatorSpeed);
    }
    
    private float SpeedCurrent;
    private float SpeedVelocity;
    
    private float SmoothSpeed()
    {
        if (OnCast && SpeedCurrent > Speed / 2.0f) SpeedCurrent =
            Mathf.SmoothDamp(SpeedCurrent, Speed / 2.0f, ref SpeedVelocity, SmoothTime);
        
        else if (!OnCast && SpeedCurrent < Speed) SpeedCurrent =
            Mathf.SmoothDamp(SpeedCurrent, Speed, ref SpeedVelocity, SmoothTime);

        return SpeedCurrent;
    }
}