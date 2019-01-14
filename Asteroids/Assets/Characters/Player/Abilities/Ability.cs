using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public abstract class Ability : MonoBehaviour
{
    [SerializeField]
    private string activationButton;

    [SerializeField]
    float cooldown = 8;
    
    private float currentCooldown;

    void Awake()
    {
        currentCooldown = cooldown;
    }
    
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown(activationButton) && CanUse())
        {
            Debug.Log("Activate " + name);
            Activate(GetComponent<Spaceship>());
            currentCooldown = cooldown;
        }
        currentCooldown -= Time.deltaTime;
    }

    protected abstract void Activate(Spaceship spaceship);

    public bool CanUse()
    {
        return currentCooldown <= 0;
    }

    public float GetRemainingCooldown()
    {
        return currentCooldown;
    }


}
