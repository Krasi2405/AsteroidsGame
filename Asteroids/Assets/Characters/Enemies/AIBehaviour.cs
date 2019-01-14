using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Spaceship))]
[RequireComponent(typeof(EnemyDetection))]
public abstract class AIBehaviour : MonoBehaviour
{
    protected Weapon weapon;
    private Health health;
    private EnemyDetection detection;
    protected FlyModeController flyModeController;

    protected PlayerController player;

    private bool hasEngaged = false;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
        health = GetComponent<Health>();
        detection = GetComponent<EnemyDetection>();
        flyModeController = GetComponent<FlyModeController>();

        player = FindObjectOfType<PlayerController>();
    }

    Coroutine fightCoroutine;
    Coroutine seekCoroutine;
    Coroutine idleCoroutine;

    void Update()
    {
        if (!player) return;

        if (detection.CanSeeEnemy(player.gameObject))
        {
            if (fightCoroutine == null) {
                // Debug.Log("Start fight coroutine!");
                if (seekCoroutine != null)
                {
                    StopCoroutine(seekCoroutine);
                    seekCoroutine = null;
                }
                if (idleCoroutine != null)
                {
                    StopCoroutine(idleCoroutine);
                    idleCoroutine = null;
                }

                hasEngaged = true;
                fightCoroutine = StartCoroutine(FightBehaviour());
            }
        }
        else
        {
            if (hasEngaged)
            {
                if (seekCoroutine == null)
                {
                    // Debug.Log("Start seek coroutine!");
                    StopCoroutine(fightCoroutine);
                    fightCoroutine = null;
                    seekCoroutine = StartCoroutine(SeekBehaviour());
                }
            }
            else
            {
                if (idleCoroutine == null)
                {
                    // Debug.Log("Start idle coroutine!");
                    idleCoroutine = StartCoroutine(IdleBehaviour());
                }
            }
        }
            
    }

    protected abstract IEnumerator IdleBehaviour();
    protected abstract IEnumerator SeekBehaviour();
    protected abstract IEnumerator FightBehaviour();
}
