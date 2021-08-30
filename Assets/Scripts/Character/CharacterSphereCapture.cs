using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CharacterSphereCapture : MonoBehaviour
{
    [SerializeField] private float CaptureTime;
    [SerializeField] private float RiseTime;
    [SerializeField] private float RiseDistance;
    
    [NonSerialized] public GameObject Sphere;
    [NonSerialized] public Coroutine Coroutine;

    public void Capture()
    {
        GameObject[] SphereOnSceneGroup = GameObject.FindGameObjectsWithTag("Sphere");
        GameObject SphereOnScene = SphereOnSceneGroup[0];

        float Distance = Vector3.Distance(transform.position, SphereOnSceneGroup[0].transform.position);

        for (int i = 0; i < SphereOnSceneGroup.Length; i++)
        {
            if (Vector3.Distance(transform.position, SphereOnSceneGroup[i].transform.position) < Distance)
            {
                SphereOnScene = SphereOnSceneGroup[i];
            }
        }
        
        Sphere = SphereOnScene;
            
        Rigidbody Rigidbody = Sphere.GetComponent<Rigidbody>();
        Rigidbody.useGravity = false;

        Coroutine = StartCoroutine(Stop(Rigidbody));

        ParticleSystem Particle = Sphere.transform.GetComponentInChildren<ParticleSystem>();
        Particle.Play();

        AudioSource Audio = Sphere.GetComponent<AudioSource>();
        Audio.Play();
    }

    public void Release()
    {
        if (!Sphere) return;
        
        Rigidbody Rigidbody = Sphere.GetComponent<Rigidbody>();
        Rigidbody.useGravity = true;
            
        if (Coroutine != null) StopCoroutine(Coroutine);
        
        ParticleSystem Particle = Sphere.transform.GetComponentInChildren<ParticleSystem>();
        Particle.Stop();
    }
    
    private IEnumerator Stop(Rigidbody Rigidbody)
    {
        Vector3 CaptureVelocity = new Vector3();
        Vector3 RiseVelocity = new Vector3();
        
        while (InMotion(Rigidbody) || OnGround(Rigidbody))
        {
            Rigidbody.velocity = Vector3.SmoothDamp(Rigidbody.velocity, new Vector3(),
                ref CaptureVelocity, CaptureTime);

            if (OnGround(Rigidbody))
            {
                Rigidbody.transform.position = Vector3.SmoothDamp(Rigidbody.transform.position, new Vector3(
                    Rigidbody.transform.position.x, RiseDistance, Rigidbody.transform.position.z), ref RiseVelocity, RiseTime);
            }

            yield return new WaitForEndOfFrame();
        }
    }
    
    private bool InMotion(Rigidbody Rigidbody)
    {
        return Rigidbody.velocity != new Vector3();
    }
    
    private bool OnGround(Rigidbody Rigidbody)
    {
        float GroundDistance = 0.0f;
        
        if (Physics.Raycast(Rigidbody.transform.position, new Vector3(
            0.0f, -1.0f, 0.0f), out RaycastHit Hit)) GroundDistance = Hit.distance;
        
        return GroundDistance < RiseDistance;
    }
}
