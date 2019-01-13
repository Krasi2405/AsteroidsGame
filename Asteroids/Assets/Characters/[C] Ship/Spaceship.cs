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
            Die();
        }
        StabilizeShip();
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

        StartCoroutine(StabilizeShip());
    }

    private void OnCollisionExit(Collision collision)
    {
        StartCoroutine(StabilizeShip());
    }

    private IEnumerator StabilizeShip()
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 position = transform.position;
            position.y = 0;
            transform.position = position;
            Debug.Log("Set position to " + position);

            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.x = 0;
            rotation.z = 0;
            Debug.Log("Set rotation to " + rotation);
            transform.rotation = Quaternion.Euler(rotation);
            
            yield return new WaitForEndOfFrame();
        }
    }
}
