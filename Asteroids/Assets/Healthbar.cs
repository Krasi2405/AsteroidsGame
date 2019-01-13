using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField]
    private Image healthbar;

    [SerializeField]
    private Spaceship player;

    [SerializeField]
    private float maxHitpoints;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<Spaceship>();
        maxHitpoints = player.GetHitpoints();
    }

    private void Update()
    {
        float hp = player.GetHitpoints();
        float scale = hp / maxHitpoints;
        
        if(scale < 0)
        {
            scale = 0;
        }

        healthbar.transform.localScale = new Vector3(scale, 1, 1);
    }
}
