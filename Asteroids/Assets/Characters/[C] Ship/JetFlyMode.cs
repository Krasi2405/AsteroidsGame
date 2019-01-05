using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(FlyModeController))]
public class JetFlyMode : FlyMode {
    [SerializeField]
    private float acceleration = 5f;

    [SerializeField]
    [Range(0, 1)]
    private float accelerationInfluence = 0.6f;

    [SerializeField]
    private float torque = 5f;

    [SerializeField]
    private float wingTippingRotation = 30;

    [SerializeField]
    private float wingTippingPerSecond = 90;

    

    private Rigidbody rigidbody;


    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}


    public override void HandleInput(float horizontalInput, float verticalInput, Vector3 targetLocation)
    {
        float forwardSpeed = acceleration + acceleration * (verticalInput * accelerationInfluence);

        rigidbody.AddForce(transform.forward * forwardSpeed * Time.deltaTime);
        rigidbody.AddTorque(Vector3.up * horizontalInput * torque * Time.deltaTime);

        TipWings(wingTippingRotation * horizontalInput * -1);
    }

    void TipWings(float target)
    {
        Vector3 rotation = transform.eulerAngles;
        float currentRotation = rotation.z;
        if (currentRotation > 180)
        {
            currentRotation -= 360;
        }


        float newRotation = currentRotation;
        if(currentRotation > target)
        {
            newRotation = currentRotation - wingTippingPerSecond * Time.deltaTime;
            if(newRotation < target)
            {
                newRotation = target;
            }
        }
        else if(currentRotation < target)
        {
            newRotation = currentRotation + wingTippingPerSecond * Time.deltaTime;
            if(newRotation > target)
            {
                newRotation = target;
            }
        }

        rotation.z = newRotation;
        transform.eulerAngles = rotation;
    }
}
