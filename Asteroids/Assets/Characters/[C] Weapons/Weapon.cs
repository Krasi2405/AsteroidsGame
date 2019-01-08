using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private Location[] shootingLocations;

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
        foreach (Location shootingPosition in shootingLocations)
        {
            Vector3 worldPoint = shootingPosition.GetLocation();
            Vector3 direction = shootingPosition.GetForwardDirection();
            ShootProjectile(worldPoint, direction);
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
}
