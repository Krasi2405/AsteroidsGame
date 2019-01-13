using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class ProjectileBomb : Projectile
{
    [SerializeField]
    private float targetDamage = 10;

    [SerializeField]
    private float areaOfEffectDamage = 5f;

    [SerializeField]
    private float radius = 1f;

    [SerializeField]
    private ParticleSystem explosionParticles;

    private void Update()
    {
        if(GetComponent<Health>().IsDead())
        {
            Destruct();
            Destroy(gameObject);
        }
    }

    protected override void Destruct()
    {
        DealAreaOfEffectDamage();
    }

    protected override void ShootEffect(GameObject gameObj)
    {
        Health health = gameObj.GetComponent<Health>();
        health.TakeDamage(targetDamage);
        Destroy(gameObject);
    }


    private void DealAreaOfEffectDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider collider in colliders)
        {
            Health health = collider.GetComponent<Health>();
            if(health)
            {
                health.TakeDamage(areaOfEffectDamage);
            }
        }

        if (explosionParticles)
        {
            ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
            particles.Play();
            Destroy(particles, particles.time);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
