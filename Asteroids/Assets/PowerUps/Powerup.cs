using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Powerup : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gameObj = other.gameObject;
        Debug.Log(gameObj.name + " enter powerup!");
        if (gameObj.GetComponent<PlayerController>())
        {
            ActivatePowerup(gameObj.GetComponent<Spaceship>());
            Destroy(gameObject);
        }
    }

    protected abstract void ActivatePowerup(Spaceship spaceship);
}

