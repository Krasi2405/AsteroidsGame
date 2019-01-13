using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointReset : MonoBehaviour
{
    [SerializeField] // TODO: Remove SerializeField
    private string lastLevelName = "";

    private static CheckpointReset Instance;

    private void Awake()
    {
        
        if(Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if(lastLevelName == "")
        {
            lastLevelName = SceneManager.GetActiveScene().name;
        }
    }

    public void ResetCheckpoint()
    {
        PlayerPrefs.SetInt(lastLevelName + "_checkpoints", 0);
    }

    public string GetLastSceneName()
    {
        return lastLevelName;
    }
}


