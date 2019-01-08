using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public Vector3 GetLocation()
    {
        return transform.position;
    }

    public Vector3 GetForwardDirection()
    {
        return transform.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.4f);
        Gizmos.DrawRay(transform.position, GetForwardDirection() * 2);
    }
}
