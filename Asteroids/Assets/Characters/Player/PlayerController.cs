using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(JetFlyMode))]
[RequireComponent(typeof(HelicopterFlyMode))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private string modeSwitchActivationKey;

    [SerializeField]
    ParticleSystem explosionParticles;

    [SerializeField]
    private float maxHealth = 100;

    private float currentHealth;

    private Animator animator;

    private bool canSwitchMode = true;
    private bool switchModeTrigger = false;
    
    FlyMode[] flyModes;

    FlyMode currentFlyMode;

    int currentFlyModeCount = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        flyModes = GetComponents<FlyMode>();
        if (flyModes.Length == 0)
        {
            Debug.LogError("Player cannot fly with no fly modes!");
            Destroy(gameObject);
        }
        else if (flyModes.Length != 2)
        {
            Debug.LogWarning("Player balacing centered around 2 fly modes!");
        }

        
        currentFlyMode = flyModes[currentFlyModeCount];
        Debug.Log("Mode: " + currentFlyMode.GetAnimationTriggerName());

        currentHealth = maxHealth;
    }

    private void Update()
    {
        HandleMovement();

        if (CrossPlatformInputManager.GetButtonDown(modeSwitchActivationKey) && canSwitchMode)
        {
            SwitchMode();
        }
    }



    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(particles, particles.time);

        Destroy(gameObject, 0.1f);

        FindObjectOfType<LevelStateManager>().Lose();
    }

    private void HandleMovement()
    {
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");

        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        currentFlyMode.HandleInput(horizontalInput, verticalInput, mousePositionWorldSpace);
    }

    private void SwitchMode()
    {
        if(!canSwitchMode)
        {
            return;
        }
        canSwitchMode = false;

        currentFlyModeCount += 1;
        if(currentFlyModeCount >= flyModes.Length)
        {
            currentFlyModeCount = 0;
        }

        Debug.Log(flyModes[currentFlyModeCount].GetAnimationTriggerName());
        animator.SetTrigger(flyModes[currentFlyModeCount].GetAnimationTriggerName());
        StartCoroutine(SetLockTime());
    }

    // Takes time for animator trigger to take effect.
    // Get length in next frame
    private IEnumerator SetLockTime()
    {
        yield return new WaitForEndOfFrame();

        float length = animator.GetCurrentAnimatorStateInfo(0).length;
        
        Invoke("UnlockModeSwitch", length);
        Invoke("ActivateCurrentFlyMode", length / 2);
    }

    private void ActivateCurrentFlyMode()
    {
        foreach (FlyMode mode in flyModes)
        {
            mode.enabled = false;
        }
        currentFlyMode = flyModes[currentFlyModeCount];
        currentFlyMode.enabled = true;
    }

    private void UnlockModeSwitch()
    {
        canSwitchMode = true;
    }

}