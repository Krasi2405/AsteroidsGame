using System.Collections;
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
    ParticleSystem explosionParticles;

    void Start()
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
        ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(particles, particles.time);
        Destroy(gameObject, 0.1f);
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
    }
}
