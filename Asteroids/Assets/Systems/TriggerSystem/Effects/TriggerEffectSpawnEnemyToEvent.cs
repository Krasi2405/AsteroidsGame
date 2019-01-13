using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectSpawnEnemyToEvent : TriggerEffect
{
    [SerializeField]
    private Spaceship enemyPrefab;

    [SerializeField]
    private Location[] spawnLocations;

    public override void ActivateEffect()
    {
        foreach (Location spawnLocation in spawnLocations)
        {
            Quaternion rotation = Quaternion.Euler(spawnLocation.GetForwardDirection());
            Spaceship enemy = Instantiate(enemyPrefab, spawnLocation.GetLocation(), rotation);
            GetComponent<TriggerEventDestroyEnemies>().AddSpaceship(enemy);
        }
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
