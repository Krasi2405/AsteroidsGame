using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField]
    private Ability ability;

    [SerializeField]
    private Image coverImage;

    private float maxCooldown;


    void Start()
    {
        maxCooldown = ability.GetRemainingCooldown();
    }

    void Update()
    {
        float cooldown = ability.GetRemainingCooldown();
        float yScale = cooldown / maxCooldown;
        if(yScale < 0)
        {
            yScale = 0;
        }

        Vector3 scale = coverImage.transform.localScale;
        scale.y = yScale;
        coverImage.transform.localScale = scale;
    }
}
