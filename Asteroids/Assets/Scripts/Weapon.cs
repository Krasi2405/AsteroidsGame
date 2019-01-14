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
		if(lastShot >= shotDelay)
        {
            Shoot();
            lastShot = 0;
        }
        else
        {
            lastShot += Time.deltaTime;
        }
	}


    private void Shoot()
    {
        Projectile projectile = Instantiate(
            projectilePrefab, 
            transform.position, 
            Quaternion.Euler(transform.forward)
        );
        projectile.SetParent(gameObject);
    }
}
