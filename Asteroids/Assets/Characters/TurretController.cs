using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Turret))]
[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyDetection))]
public class TurretController : MonoBehaviour
{
    Turret turret;
    Weapon weapon;
    Health health;
    EnemyDetection detection;

    PlayerController player;

    [SerializeField]
    private float sightDistance = 50;

    void Start()
    {
        turret = GetComponent<Turret>();
        weapon = GetComponent<Weapon>();
        health = GetComponent<Health>();
        detection = GetComponent<EnemyDetection>();

        player = FindObjectOfType<PlayerController>();
    }
    

    void Update()
    {
        if (detection.CanSeeEnemy(player.gameObject))
        {
            Vector3 direction = (player.transform.position - transform.position);
            turret.RotateTo(direction);

            weapon.RequestShoot();
        }
    }
}
