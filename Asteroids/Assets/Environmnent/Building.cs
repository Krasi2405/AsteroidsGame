using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Building : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObj = collision.gameObject;
        if(gameObj.GetComponent<Health>())
        {
            // Oneshot
            gameObj.GetComponent<Health>().TakeDamage(9999);
        }
    }

    // TODO: Do something cool with buildings here. Probably only sound FX but lots of room for improvement.
}
