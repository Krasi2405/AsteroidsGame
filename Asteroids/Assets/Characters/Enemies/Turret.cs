using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Weapon))]
public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject horizontalPlatform;

    [SerializeField]
    private GameObject destroyedPrefab;

    [SerializeField]
    private ParticleSystem explosionParticles;

    [SerializeField]
    private AudioClip destructionSound;

    [SerializeField]
    private float horizontalRotationSpeed = 20f;

    private Health health;
    private Weapon weapon;


    void Start()
    {
        if(horizontalPlatform.transform.localEulerAngles != Vector3.zero)
        {
            Debug.LogWarning("Horizontal platform on " + horizontalPlatform.name + 
                " turret needs to be (0, 0, 0) in order to work properly!");
            Debug.LogWarning(horizontalPlatform.transform.localEulerAngles);
        }
        health = GetComponent<Health>();
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if(health.IsDead())
        {
            if(destructionSound)
                AudioSource.PlayClipAtPoint(destructionSound, transform.position);

            Die();
        }
    }

    public void RotateTo(Vector3 direction)
    {
        Vector3 lookAtRotation = Quaternion.LookRotation(direction).eulerAngles;
        RotateHorizontal(lookAtRotation.y);
    }

    private void Die()
    {
        if (explosionParticles)
        {
            ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.time);
        }

        if(destroyedPrefab)
        {
            Instantiate(destroyedPrefab, transform.position, transform.rotation);
        }

        Destroy(gameObject, 0.1f);
    }


    private void RotateHorizontal(float targetDegrees)
    {
        
        float degrees = horizontalPlatform.transform.eulerAngles.y;
        degrees = RotationHelper.IncrementalDegreeRotation(
            degrees, 
            targetDegrees,
            horizontalRotationSpeed * Time.deltaTime
        );

        Vector3 newRotation = new Vector3(
            horizontalPlatform.transform.rotation.x,
            degrees,
            horizontalPlatform.transform.rotation.z
        );

        horizontalPlatform.transform.eulerAngles = newRotation;
    }
}
