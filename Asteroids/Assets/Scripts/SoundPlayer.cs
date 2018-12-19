using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {

    [SerializeField]
    private AudioClip audio;

    [SerializeField]
    private string tag;

    public string GetTag()
    {
        return tag;
    }

    private void Start()
    {
        GetComponent<AudioSource>().clip = audio;
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
