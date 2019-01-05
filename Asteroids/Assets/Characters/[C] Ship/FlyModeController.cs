using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlyMode))]
public class FlyModeController : MonoBehaviour
{
    private Animator animator;

    FlyMode[] flyModes;
    FlyMode currentFlyMode;

    int currentFlyModeCount = 0;

    private bool canSwitchMode = true;
    private bool switchModeTrigger = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        flyModes = GetComponents<FlyMode>();
        if (flyModes.Length == 0)
        {
            Debug.LogError(name + " cannot fly with no fly modes!");
            Destroy(gameObject);
        }

        currentFlyMode = flyModes[currentFlyModeCount];
    }
    
    public void HandleInput(float horizontalInput, float verticalInput, Vector3 targetLocation)
    {
        currentFlyMode.HandleInput(horizontalInput, verticalInput, targetLocation);
    }

    public void RequestSwitchMode()
    {
        if (!canSwitchMode)
        {
            return;
        }
        canSwitchMode = false;

        currentFlyModeCount += 1;
        if (currentFlyModeCount >= flyModes.Length)
        {
            currentFlyModeCount = 0;
        }

        Debug.Log(flyModes[currentFlyModeCount].GetAnimationTriggerName());
        animator.SetTrigger(flyModes[currentFlyModeCount].GetAnimationTriggerName());

        StartCoroutine(SetLockTime());
    }

    // Takes time for animator trigger to take effect.
    // Get length of animation clip in next frame
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
