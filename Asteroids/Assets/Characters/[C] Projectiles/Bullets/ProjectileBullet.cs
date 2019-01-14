using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileBullet : Projectile
{
    [SerializeField]
    private float damage = 5;

    protected override void ShootEffect(GameObject gameObj)
    {
        gameObj.GetComponent<Health>().TakeDamage(damage);
        Destroy(gameObject);
    }
}
