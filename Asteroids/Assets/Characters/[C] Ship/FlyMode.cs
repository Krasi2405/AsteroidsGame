using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FlyModeController))]
public abstract class FlyMode : MonoBehaviour
{
    [SerializeField]
    private string animationTriggerName;

    [SerializeField]
    protected AudioClip movementSound;

    public string GetAnimationTriggerName()
    {
        return animationTriggerName;
    }

    public abstract void HandleInput(float horizontalInput, float verticalInput, Vector3 targetLocation);

    protected void PlayFlySound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        
        if(!audioSource)
            return;

        audioSource.clip = movementSound;
        audioSource.volume = 1;
        audioSource.Play();
    }

    protected void StopFlySound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (!audioSource || !audioSource.isPlaying)
            return;

        audioSource.Stop();
    }

    private void OnEnable()
    {
        if (GetComponent<AudioSource>())
        {
            PlayFlySound();
        }
    }

    private void OnDisable()
    {
        if (GetComponent<AudioSource>())
        {
            StopFlySound();
        }
    }
}
