using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventDestroyEnemies : TriggerEvent
{
    [SerializeField]
    List<Spaceship> spaceships = new List<Spaceship>();

    private bool hasCalledFX = false;

    void Update()
    {
        if(hasCalledFX) { return;  }

        // Really bad implementation!!!
        for(int i = 0; i < spaceships.Count; i++)
        {
            if(spaceships[i] == null)
            {
                spaceships.RemoveAt(i);
            }
        }

        if(spaceships.Count == 0)
        {
            hasCalledFX = true;
            StartCoroutine(CallTriggerEffects());
        }    
    }

    public void AddSpaceship(Spaceship spaceship)
    {
        spaceships.Add(spaceship);
    }
}
