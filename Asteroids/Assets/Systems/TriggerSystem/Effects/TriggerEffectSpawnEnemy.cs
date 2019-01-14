using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectSpawnEnemy : TriggerEffect
{
    [SerializeField]
    private Spaceship enemyPrefab;

    [SerializeField]
    private Location[] spawnLocations;

    public override void ActivateEffect()
    {
        foreach(Location spawnLocation in spawnLocations)
        {
            Spaceship enemy = Instantiate(
                enemyPrefab, spawnLocation.GetLocation(), 
                Quaternion.LookRotation(spawnLocation.GetForwardDirection())
            );
        }
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
