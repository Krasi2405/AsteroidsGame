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
            Quaternion rotation = Quaternion.Euler(spawnLocation.GetForwardDirection());
            Instantiate(enemyPrefab, spawnLocation.GetLocation(), rotation);
        }
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
