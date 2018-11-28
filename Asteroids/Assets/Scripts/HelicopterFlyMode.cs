using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HelicopterFlyMode : MonoBehaviour {

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    [Range(0, 1f)]
    private float rotationLerpSpeed = 0.05f;


	void Update () {
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        // Rotate
        Quaternion currentRotation = transform.rotation;
        transform.LookAt(mousePositionWorldSpace);
        transform.rotation = Quaternion.Lerp(currentRotation, transform.rotation, rotationLerpSpeed);

        // Move
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction *= speed * Time.deltaTime;
        transform.Translate(direction, Space.World);
    }
}
