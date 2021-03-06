﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(FlyModeController))]
[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Rigidbody))]
public class Spaceship : MonoBehaviour
{
    private Health health;
    private FlyModeController flyModeController;
    private Weapon weapon;

    [SerializeField]
    private ParticleSystem explosionParticles;

    [SerializeField]
    private AudioClip destructionSound;

    void Awake()
    {
        health = GetComponent<Health>();
        flyModeController = GetComponent<FlyModeController>();
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        if(health.IsDead())
        {
            if (destructionSound)
                AudioSource.PlayClipAtPoint(destructionSound, transform.position);

            Die();
        }
        StabilizeShip(); // really tired of rigidbodies.
    }

    public void RequestShoot()
    {
        weapon.RequestShoot();
    }

    public void HandleInput(float horizontalInput, float verticalInput, Vector3 targetLocation)
    {
        flyModeController.HandleInput(horizontalInput, verticalInput, targetLocation);
    }

    public void SwitchMode()
    {
        flyModeController.RequestSwitchMode();
    }

    public float GetHitpoints()
    {
        return health.GetHitpoints();
    }

    public void AddHitpoints(float additional)
    {
        health.AddHitpoints(additional);
    }

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
    }

    public void PlayClip(AudioClip audioClip)
    {

    }

    private void Die()
    {
        if (explosionParticles)
        {
            ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.time);
        }

        if(destructionSound)
        {
            AudioSource.PlayClipAtPoint(destructionSound, transform.position);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObj = collision.gameObject;
        if(gameObj.tag != gameObject.tag && (gameObj.GetComponent<Spaceship>() || gameObj.GetComponent<Turret>()))
        {
            Health otherHealth = gameObj.GetComponent<Health>();
            float smallerHealth = otherHealth.GetHitpoints();
            if(health.GetHitpoints() < smallerHealth)
            {
                smallerHealth = health.GetHitpoints();
            }

            otherHealth.TakeDamage(smallerHealth);
            health.TakeDamage(smallerHealth);
        }

        if (GetComponent<Health>().IsDead()) return;
       
    }


    // Simulates kinematic rigidbody.
    // Needed to because no own collision detection if no rigidbody.
    private void StabilizeShip()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;

        Vector3 rotation = transform.eulerAngles;
        rotation.x = 0;
        transform.rotation = Quaternion.Euler(rotation);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
    }
}
