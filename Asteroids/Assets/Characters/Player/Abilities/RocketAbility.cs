using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAbility : Ability
{
    [SerializeField]
    private Weapon rocketWeapon;

    protected override void Activate(Spaceship spaceship)
    {
        rocketWeapon.RequestShoot();
    }
}
