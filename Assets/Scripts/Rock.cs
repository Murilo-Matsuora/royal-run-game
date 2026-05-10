using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource boulderSmashAudioSource;
    [SerializeField] float volumeModifier = 10f;
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float xShakeLimit = 0.5f;
    [SerializeField] float zShakeLimit = 0.5f;
    [SerializeField] float collisionFXCooldown = 1f;
    CinemachineImpulseSource cinemachineImpulseSource;
    float collisionTimer = 1f;

    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collisionTimer < collisionFXCooldown) return;

        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        FireImpulse(distance);
        PlayCollisionParticles(collision);
        PlayCollisionSFX(distance);
        
        collisionTimer = 0f;
    }

    private void FireImpulse(float distance)
    {
        float shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        Vector3 randomImpulseVelocity = new Vector3(Random.Range(-xShakeLimit, xShakeLimit), cinemachineImpulseSource.DefaultVelocity.y, Random.Range(-zShakeLimit, zShakeLimit));
        cinemachineImpulseSource.DefaultVelocity = randomImpulseVelocity;
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void PlayCollisionParticles(Collision collision)
    {

        ContactPoint contactPoint = collision.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();

    }

    void PlayCollisionSFX(float distance)
    {
        float volume = (1f / distance) * volumeModifier;
        volume = Mathf.Clamp(volume, 0.1f, 1f);
        boulderSmashAudioSource.volume = volume;

        boulderSmashAudioSource.pitch = Random.Range(0.5f, 2f);

        boulderSmashAudioSource.Play();
        
    }


}
