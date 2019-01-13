using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HelicopterFlyMode : FlyMode {

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    [Range(0, 1f)]
    private float rotationLerpSpeed = 0.05f;

    public override void HandleInput(float horizontalInput, float verticalInput, Vector3 targetLocation)
    {
        // Rotate
        Quaternion currentRotation = transform.rotation;
        transform.LookAt(targetLocation);
        transform.rotation = Quaternion.Lerp(currentRotation, transform.rotation, rotationLerpSpeed);

        // Move
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction *= speed * Time.deltaTime;
        transform.Translate(direction, Space.World);
    }
}
