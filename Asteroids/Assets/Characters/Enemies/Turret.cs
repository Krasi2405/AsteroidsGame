using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Turret : MonoBehaviour
{
    [SerializeField]
    private GameObject horizontalPlatform;

    [SerializeField]
    private float horizontalRotationSpeed = 20f;

    private Health health;
    private Weapon weapon;


    void Start()
    {
        if(horizontalPlatform.transform.localEulerAngles != Vector3.zero)
        {
            Debug.LogWarning("Horizontal platform on " + horizontalPlatform.name + 
                " turret needs to be (0, 0, 0) in order to work properly!");
            Debug.LogWarning(horizontalPlatform.transform.localEulerAngles);
        }
        health = GetComponent<Health>();
        weapon = GetComponent<Weapon>();
    }

    public void RotateTo(Vector3 direction)
    {
        Vector3 lookAtRotation = Quaternion.LookRotation(direction).eulerAngles;
        RotateHorizontal(lookAtRotation.y);
    }

    private void RotateHorizontal(float targetDegrees)
    {
        
        float degrees = horizontalPlatform.transform.eulerAngles.y;
        degrees = RotationHelper.IncrementalDegreeRotation(
            degrees, 
            targetDegrees,
            horizontalRotationSpeed * Time.deltaTime
        );

        Vector3 newRotation = new Vector3(
            horizontalPlatform.transform.rotation.x,
            degrees,
            horizontalPlatform.transform.rotation.z
        );

        horizontalPlatform.transform.eulerAngles = newRotation;
    }
}
