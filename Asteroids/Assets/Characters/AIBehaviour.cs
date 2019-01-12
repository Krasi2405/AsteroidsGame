using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Weapon))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyDetection))]
[RequireComponent(typeof(FlyModeController))]
public abstract class AIBehaviour : MonoBehaviour
{
    Weapon weapon;
    Health health;
    EnemyDetection detection;
    FlyModeController flyModeController;

    PlayerController player;

    [SerializeField]
    private float sightDistance = 50;

    private bool hasEngaged = false;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        health = GetComponent<Health>();
        detection = GetComponent<EnemyDetection>();

        player = FindObjectOfType<PlayerController>();
    }


    void Update()
    {
        if (detection.CanSeeEnemy(player.gameObject))
        {
            hasEngaged = true;
            FightBehaviour();
        }
        else
        {
            if(hasEngaged)
            {
                SeekBehaviour();
            }
            else
            {
                IdleBehaviour();
            }
        }
    }

    protected abstract void IdleBehaviour();
    protected abstract void SeekBehaviour();
    protected abstract void FightBehaviour();
}
