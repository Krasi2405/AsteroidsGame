﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float hitpoints = 100;

    [SerializeField]
    private float currentHitpoints;

    void Start()
    {
        currentHitpoints = hitpoints;
    }

    public void AddHitpoints(float additional)
    {
        currentHitpoints += additional;
        if(currentHitpoints > hitpoints)
        {
            currentHitpoints = hitpoints;
        }
    }

    public float GetHitpoints()
    {
        return currentHitpoints;
    }

    public void TakeDamage(float damage)
    {
        currentHitpoints -= damage;
    }

    public bool IsDead()
    {
        return currentHitpoints <= 0;
    }
}
