using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

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

    public override void HandleInput(float horizontalInput, float verticalInput, Vector3 targetLocation)
    {
        float forwardSpeed = acceleration + acceleration * (verticalInput * accelerationInfluence);

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontalInput * torque * Time.deltaTime, 0), Space.World);

        TipWings(wingTippingRotation * horizontalInput * -1);

        
        if(GetComponent<AudioSource>())
        {
            GetComponent<AudioSource>().volume = 0.5f + verticalInput / 4;
        }
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
