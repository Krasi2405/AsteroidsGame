using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Projectile))]
public class Heatseeking : MonoBehaviour
{
    [SerializeField]
    private float heatRange = 20f;

    [SerializeField]
    private float rotationSpeedPerSecond = 60f;

    [SerializeField]
    private float fuelTime = 2f;
    

    [SerializeField] // TODO: Remove serializefield
    GameObject target;
    private void Start()
    {
        StartCoroutine(PickupTarget());
    }

    void Update()
    {
        if(target && fuelTime >= 0) {
            float targetDegrees = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles.y;
            float degrees = RotationHelper.IncrementalDegreeRotation(
                transform.rotation.eulerAngles.y,
                targetDegrees,
                rotationSpeedPerSecond * Time.deltaTime
            );

            Vector3 newRotation = new Vector3(
                transform.rotation.eulerAngles.x,
                degrees,
                transform.rotation.eulerAngles.z
            );
            
            transform.eulerAngles = newRotation;
            fuelTime -= Time.deltaTime;
        }
    }

    private IEnumerator PickupTarget()
    {
        while(true)
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, heatRange);
            foreach(Collider collider in targets)
            {
                GameObject target = collider.gameObject;
                if(target.GetComponent<Spaceship>() && 
                   target.tag != GetComponent<Projectile>().GetParent().tag &&
                   target.tag != gameObject.tag)
                {
                    this.target = target;
                }
            }
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, heatRange);
    }
}
