using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Location
{
    public void LoadCheckpoint()
    {
        FindObjectOfType<PlayerController>().transform.position = transform.position;
        Camera.main.transform.position = transform.position;

        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint checkpoint in checkpoints)
        {
            if(checkpoint.transform.position.x < transform.position.x)
            {
                Destroy(checkpoint);
            }
        }

        Spaceship[] spaceships = FindObjectsOfType<Spaceship>();
        foreach(Spaceship spaceship in spaceships)
        {
            if (spaceship.transform.position.x < transform.position.x)
            {
                Destroy(spaceship.gameObject);
            }
        }

        TurretController[] turrets = FindObjectsOfType<TurretController>();
        foreach (TurretController turret in turrets)
        {
            if (turret.transform.position.x < transform.position.x)
            {
                Destroy(turret.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "Save.png");
    }
}
