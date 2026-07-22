using Unity.Cinemachine;
using UnityEngine;

public class Rockcollison : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    [SerializeField] AudioSource audio;

    float cooldowntime = 075f;
    float collisiontimer = 0f;

    CinemachineImpulseSource cinemachineImpulseSource;
    

    private void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        collisiontimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (collisiontimer > cooldowntime) return;
        cinemachineImpulseSource.GenerateImpulse();
        collisionfx(other);
        collisiontimer = 0f;
    }
    
    void collisionfx(Collision other)
    {
        ContactPoint contactpont = other.contacts[0];
        particle.transform.position = contactpont.point;
        audio.Play();
        particle.Play();
       
    }
}
