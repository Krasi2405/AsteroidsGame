using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventDestroyEnemies : TriggerEvent
{
    [SerializeField]
    List<GameObject> spaceships = new List<GameObject>();

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

    public void AddSpaceship(GameObject spaceship)
    {
        spaceships.Add(spaceship);
    }
}
