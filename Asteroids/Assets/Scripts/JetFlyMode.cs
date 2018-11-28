using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class JetFlyMode : MonoBehaviour {
    [SerializeField]
    private float acceleration = 5f;

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
	
	void Update () {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        rigidbody.AddForce(transform.forward * verticalInput * acceleration * Time.deltaTime);
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
