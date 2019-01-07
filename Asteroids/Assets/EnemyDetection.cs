using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField]
    private float sightDistance = 50;

    public bool CanSeeEnemy(GameObject enemy)
    {
        // TODO: Check for objects in sight.
        Vector3 direction = (transform.position - enemy.transform.position);
        float sight = Mathf.Sqrt(direction.sqrMagnitude);
        if (sight <= sightDistance)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, sightDistance);
    }
}
