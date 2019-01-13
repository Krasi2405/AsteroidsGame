using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterFlyModeRelative : FlyMode
{
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
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }
}
