using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)) {
            TogglePlayerCollisions();
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            FindObjectOfType<LevelStateManager>().Win();
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            FindObjectOfType<LevelStateManager>().Lose();
        }
    }


    void TogglePlayerCollisions()
    {
        Collider playerCollider = FindObjectOfType<PlayerController>().GetComponent<Collider>();
        if (FindObjectOfType<AlertBox>())
        {
            if (playerCollider.enabled)
            {
                FindObjectOfType<AlertBox>().Flash("Disable collider!");
            }
            else
            {
                FindObjectOfType<AlertBox>().Flash("Enable collider!");
            }
        }
        playerCollider.enabled = !playerCollider.enabled;
    }
}
