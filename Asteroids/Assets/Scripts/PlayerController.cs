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

    private Animator animator;

    private bool canSwitchMode = true;
    private bool switchModeTrigger = false;

    JetFlyMode jetMode;
    HelicopterFlyMode heliMode;

    private void Start()
    {
        jetMode = GetComponent<JetFlyMode>();
        heliMode = GetComponent<HelicopterFlyMode>();
        animator = GetComponent<Animator>();

        jetMode.enabled = true;
        heliMode.enabled = false;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown(modeSwitchActivationKey) && canSwitchMode)
        {
            if (heliMode.enabled)
            {
                animator.SetTrigger("HoverToFlyingTrigger");
            }
            else if(jetMode.enabled)
            {
                animator.SetTrigger("FlyingToHoverTrigger");
            }
            else
            {
                throw new UnityException("No fly modes enabled!");
            }
            
            canSwitchMode = false;
            switchModeTrigger = true;
        }
    }

    private void LateUpdate()
    {
        if(switchModeTrigger)
        {
            float length = animator.GetCurrentAnimatorStateInfo(0).length;
            Debug.Log(length);
            Invoke("UnlockModeSwitch", length);
            Invoke("SwitchMode", length / 2);
            switchModeTrigger = false;
        }
    }

    public void Die()
    {
        ParticleSystem particles = Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Destroy(particles, particles.time);

        Destroy(gameObject, 0.1f);
    }

    private void UnlockModeSwitch()
    {
        canSwitchMode = true;
    }

    private void SwitchMode()
    {
        heliMode.enabled = !heliMode.enabled;
        jetMode.enabled = !jetMode.enabled;
    }

}