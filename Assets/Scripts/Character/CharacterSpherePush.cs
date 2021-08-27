using UnityEngine;

public class CharacterSpherePush : MonoBehaviour
{
    [SerializeField] private float Force;

    private CharacterSphereCapture Capture;

    private void Awake()
    {
        Capture = GetComponentInParent<CharacterSphereCapture>();
    }

    public void Push(Vector3 Direction)
    {
        if (!Capture.Sphere) return;

        Rigidbody Rigidbody = Capture.Sphere.GetComponent<Rigidbody>();
        
        Rigidbody.isKinematic = false;
        Rigidbody.AddForce(Vector3.Normalize(new Vector3(Direction.x, 0.5f,
            Direction.z)) * Force);
    }
}