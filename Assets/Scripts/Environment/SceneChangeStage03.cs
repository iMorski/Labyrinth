using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeStage02 : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    private void OnTriggerEnter(Collider Other)
    {
        if (!Other.CompareTag("Player")) return;
        
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        Animator.Play("Ui-Plane-Fade-In");
        
        yield return new WaitForSeconds(1.0f);
        
        SceneManager.LoadScene(2);
    }
}
