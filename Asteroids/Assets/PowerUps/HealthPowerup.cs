using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : Powerup
{
    [SerializeField]
    private float flatHealthPoints = 20f;

    protected override void ActivatePowerup(Spaceship spaceship)
    {
        float hp = flatHealthPoints;
        spaceship.AddHitpoints(hp);
    }
}
