using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffectShowDialogue : TriggerEffect
{
    [SerializeField]
    private Dialogue dialogue;

    public override void ActivateEffect()
    {
        FindObjectOfType<DialogueBox>().ShowDialogue(dialogue);
    }

    public override bool IsAsynchronous()
    {
        return true;
    }
}
