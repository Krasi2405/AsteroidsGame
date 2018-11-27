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

    private Rigidbody rigidbody;

    void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        rigidbody.AddForce(transform.forward * verticalInput * acceleration * Time.deltaTime);
        rigidbody.AddTorque(Vector3.up * horizontalInput * torque * Time.deltaTime);
        
        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = wingTippingRotation * horizontalInput * -1;
        transform.eulerAngles = newRotation;
	}
}
