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

        if (CrossPlatformInputManager.GetButtonDown(modeSwitchActivationKey))
        {
            ship.SwitchMode();
        }

        if(CrossPlatformInputManager.GetButton(shootingKey))
        {
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

    

}