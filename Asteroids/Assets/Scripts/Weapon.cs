using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private float shotPerSecond = 5;

    private float shotDelay;
    private float lastShot = 0;

	void Start () {
        shotDelay = 1 / shotPerSecond;
	}
	

	void Update () {
		if(Time.time >= lastShot)
        {
            Shoot();
            lastShot = Time.time + shotDelay;
        }
	}


    private void Shoot()
    {
        Projectile projectile = Instantiate(
            projectilePrefab, 
            transform.position, 
            Quaternion.Euler(transform.forward)
        );

        projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectile.GetSpeed());
    }
}
