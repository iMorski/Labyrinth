using System.Collections.Generic;
using UnityEngine;

public class SphereReturn : MonoBehaviour
{
    [SerializeField] private GameObject[] Sphere;
    [SerializeField] private ParticleSystem LightningStrike;

    private List<Vector3> Position = new List<Vector3>();

    private void Awake()
    {
        for (int i = 0; i < Sphere.Length; i++)
        {
            Position.Add(Sphere[i].transform.position);
        }
    }

    private void OnTriggerEnter(Collider Other)
    {
        int Count = 0;

        for (int i = 0; i < Sphere.Length; i++)
        {
            if (!(Sphere[i] != Other.gameObject))
            {
                Count = i;

                break;
            }   
        }
        
        Sphere[Count].GetComponent<Rigidbody>().velocity = new Vector3();
        Sphere[Count].transform.position = Position[Count];
        
        Instantiate(LightningStrike, Position[Count], LightningStrike.transform.rotation);
    }
}
