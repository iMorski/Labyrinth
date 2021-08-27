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

    public virtual void OnTouchTapBegin()
    {
        Animator.Play("Ui-Push-In");
    }
    
    public virtual void OnTouchTapFinish()
    {
        Animator.Play("Ui-Push-Out");
    }
}
