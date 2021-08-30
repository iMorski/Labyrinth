using UnityEngine;

public class TrapPlane : MonoBehaviour
{
    private Trap Trap;

    private void Awake()
    {
        Trap = GetComponentInParent<Trap>();
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (!Trap.Hit && Other.CompareTag("Player"))
        {
            StartCoroutine(Trap.Death(Other));
        }
    }
}
