using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private GameObject BloodExplosion;
    [SerializeField] private GameObject BloodPool;
    
    [NonSerialized] public bool Hit;

    public IEnumerator Death(Collider Other)
    {
        Hit = true;
        
        Other.GetComponent<PlayerMovement>().enabled = false;
        Other.GetComponent<PlayerSphereCapture>().enabled = false;
        Other.GetComponent<PlayerSpherePush>().enabled = false;
        
        Other.GetComponentInChildren<Animator>().Play("Die");
        
        Instantiate(BloodExplosion, new Vector3(Other.transform.position.x, 1.0f,
            Other.transform.position.z), BloodExplosion.transform.rotation);
        Instantiate(BloodPool, new Vector3(Other.transform.position.x, 0.05f,
            Other.transform.position.z), BloodPool.transform.rotation);

        yield return new WaitForSeconds(1.0f);
        
        Animator.Play("Ui-Plane-Fade-In");
        
        yield return new WaitForSeconds(1.0f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
