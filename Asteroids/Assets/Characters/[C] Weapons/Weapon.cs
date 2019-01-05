using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private Vector3[] shootingLocations;

    [SerializeField]
    private float shotPerSecond = 5;

    private float shotDelay;

    private bool canShoot = true;

	void Start () {
        shotDelay = 1 / shotPerSecond;
	}

    public void RequestShoot()
    {
        if(canShoot)
        {
            canShoot = false;
            Shoot();
            StartCoroutine(activateShooting());
        }
    }

    private IEnumerator activateShooting()
    {
        yield return new WaitForSeconds(shotDelay);
        canShoot = true;
    }


    private void Shoot()
    {
        foreach (Vector3 shootingPosition in shootingLocations)
        {
            ShootProjectile(transform.position + shootingPosition, transform.forward);
        }
    }

    private void ShootProjectile(Vector3 position, Vector3 direction)
    {
        Debug.Log("Shoot projectile!");
        Projectile projectile = Instantiate(
            projectilePrefab,
            position,
            Quaternion.Euler(transform.forward)
        );

        projectile.SetParent(gameObject);
        projectile.SetTarget(direction);
    }


    private void OnDrawGizmos()
    {
        foreach(Vector3 location in shootingLocations)
        {
            Gizmos.DrawWireSphere(transform.position + location, 0.2f);
        }
    }
}
