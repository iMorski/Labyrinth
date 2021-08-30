using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeStage01 : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    private void Awake()
    {
        Animator.Play("Ui-Plane-Fade-Out");
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (!Other.CompareTag("Player")) return;
        
        StartCoroutine(NextScene());
    }

    private IEnumerator NextScene()
    {
        Animator.Play("Ui-Plane-Fade-In");
        
        yield return new WaitForSeconds(1.0f);
        
        SceneManager.LoadScene(0);
    }
}
