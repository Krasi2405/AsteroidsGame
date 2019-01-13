﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : AIBehaviour
{
    [SerializeField]
    private ParticleSystem weaponWelderParticles;

    [SerializeField]
    private float meleeRange = 2f;

    [SerializeField]
    private float damagePerSecond = 20;

    private Vector3 playerPosition;

    protected override IEnumerator FightBehaviour()
    {
        weaponWelderParticles.Stop();
        while (true)
        {
            playerPosition = player.transform.position;
            float distance = (playerPosition - transform.position).sqrMagnitude;
            if (distance < meleeRange)
            {
                if(!weaponWelderParticles.isPlaying)
                    weaponWelderParticles.Play();
                if (distance > meleeRange / 2)
                {
                    flyModeController.HandleInput(0, 0.4f, player.transform.position);
                }
                player.GetComponent<Health>().TakeDamage(damagePerSecond * Time.deltaTime);
            }
            else
            {
                flyModeController.HandleInput(0, 1, player.transform.position);
                if (weaponWelderParticles.isPlaying)
                    weaponWelderParticles.Stop();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    protected override IEnumerator IdleBehaviour()
    {
        while (true)
        {
            weaponWelderParticles.Play();
            yield return new WaitForSeconds(2);
            weaponWelderParticles.Stop();
            yield return new WaitForSeconds(2);
        }
    }

    protected override IEnumerator SeekBehaviour()
    {
        while(true)
        {
            if(transform.position == playerPosition)
            {
                break;
            }

            flyModeController.HandleInput(0, 0.5f, playerPosition);
            yield return new WaitForEndOfFrame();
        }
    }
}