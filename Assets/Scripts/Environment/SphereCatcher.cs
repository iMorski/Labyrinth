using System;
using UnityEngine;

public class SphereCatcher : MonoBehaviour
{
    [SerializeField] private float Distance;

    private GameObject Sphere;
    
    private void Update()
    {
        GameObject[] SphereOnSceneGroup = GameObject.FindGameObjectsWithTag("Sphere");

        if (!Sphere)
        {
            for (int i = 0; i < SphereOnSceneGroup.Length; i++)
            {
                if (Vector3.Distance(transform.position, SphereOnSceneGroup[i].transform.position) < Distance)
                {
                    Rigidbody Rigidbody = SphereOnSceneGroup[i].GetComponent<Rigidbody>();
                    Rigidbody.velocity = new Vector3();
                    Rigidbody.isKinematic = true;
                
                    SphereOnSceneGroup[i].transform.position = transform.position;

                    Sphere = SphereOnSceneGroup[i];
                }
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, Sphere.transform.position) > Distance)
            {
                Sphere = null;
            }
        }
    }
}
