using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Spaceship))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string modeSwitchActivationKey;

    [SerializeField]
    private string shootingKey;
    
    Spaceship ship;
    

    private void Start()
    {
        ship = GetComponent<Spaceship>();   
    }

    private void Update()
    {
        HandleMovement();
        RestrictMovement();
        if (CrossPlatformInputManager.GetButtonDown(modeSwitchActivationKey))
        {
            Debug.Log("Switch mode");
            ship.SwitchMode();
        }

        if(CrossPlatformInputManager.GetButton(shootingKey))
        {
            Debug.Log("Fire!");
            ship.RequestShoot();
        }
    }
    
    private void HandleMovement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        ship.HandleInput(horizontalInput, verticalInput, mousePositionWorldSpace);
    }
    
    private void RestrictMovement()
    {
        FollowCamera followCamera = FindObjectOfType<FollowCamera>();

        Vector3 topRestriction = followCamera.GetTopPoint();
        Vector3 bottomRestriction = followCamera.GetBottomPoint();
        Vector3 leftRestriction = followCamera.GetLeftPoint();
        Vector3 rightRestriction = followCamera.GetRightPoint();

        Vector3 position = transform.position;
        if (position.z > topRestriction.z)
        {
            position.z = topRestriction.z;
        }
        else if(position.z < bottomRestriction.z)
        {
            position.z = bottomRestriction.z;
        }

        if(position.x < leftRestriction.x)
        {
            position.x = leftRestriction.x;
        }
        else if(position.x > rightRestriction.x)
        {
            position.x = rightRestriction.x;
        }

        transform.position = position;
    }

    

}