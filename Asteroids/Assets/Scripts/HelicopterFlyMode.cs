using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HelicopterFlyMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);
        // transform.LookAt(mousePositionWorldSpace);


        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction = direction * 5;
        direction = direction * Time.deltaTime;
        transform.position += direction;
    }
}
