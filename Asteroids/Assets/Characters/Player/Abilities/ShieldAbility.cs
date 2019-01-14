using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : Ability
{
    [SerializeField]
    private Shield shieldObject;

    [SerializeField]
    private float shieldDuration = 2f;

    private void Start()
    {
        shieldObject.gameObject.SetActive(false);
    }

    protected override void Activate(Spaceship spaceship)
    {
        shieldObject.gameObject.SetActive(true);
        StartCoroutine(DeactivateShield());
    }

    IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(shieldDuration);
        shieldObject.gameObject.SetActive(false);
    }
}
