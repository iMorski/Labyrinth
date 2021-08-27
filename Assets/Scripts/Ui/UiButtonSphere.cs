public class UiButtonSphere : UiButton
{
    public override void OnTouchTapBegin()
    {
        base.OnTouchTapBegin();
        
        Animator.Play("Ui-Sphere-Arrow-In", 1);
    }
    
    public override void OnTouchTapFinish()
    {
        base.OnTouchTapFinish();
        
        Animator.Play("Ui-Sphere-Arrow-Out", 1);
    }
}
