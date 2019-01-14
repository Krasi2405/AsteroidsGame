using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[System.Serializable]
[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    // public because of MusicPlayerEditor;
    public List<AudioClip> audioClips = new List<AudioClip>();

    private AudioSource audioSource;

    static MusicPlayer Instance;

    private void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        
    }

    void Start()
    {
        PlayClip(SceneManager.GetActiveScene().buildIndex);
    }

    void OnLevelWasLoaded(int level)
    {
        PlayClip(level);
    }

    void PlayClip(int clipIndex)
    {
        AudioClip audioClip = audioClips[clipIndex];
        if (audioSource.clip == null || audioSource.clip != audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}