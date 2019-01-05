using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Weapon))]
public class Turret : MonoBehaviour
{
    private Health health;
    private Weapon weapon;


    void Start()
    {
        health = GetComponent<Health>();
        weapon = GetComponent<Weapon>();
    }
    
    void Update()
    {
        
    }
}
