using System;
using UnityEngine;

public class UiButton : MonoBehaviour
{
    [NonSerialized] public Animator Animator;
    
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        
        UiTouch Touch = GetComponentInChildren<UiTouch>();
        Touch.TapBegin += OnTouchTapBegin;
        Touch.TapFinish += OnTouchTapFinish;
    }

    private void OnTouchTapBegin()
    {
        Animator.Play("Ui-Push-In");
        Animator.Play("Ui-Sphere-Arrow-In", 1);
    }
    
    private void OnTouchTapFinish()
    {
        Animator.Play("Ui-Push-Out");
        Animator.Play("Ui-Sphere-Arrow-Out", 1);
    }
}
