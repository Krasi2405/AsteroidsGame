using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EnemyProjectile")
        {
            if (other.GetComponent<Health>()) {
                other.GetComponent<Health>().TakeDamage(9999);
            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }
    }
}
