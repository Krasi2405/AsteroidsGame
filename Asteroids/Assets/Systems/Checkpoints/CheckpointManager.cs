using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField]
    private Checkpoint[] checkpointLocations;

    void Start()
    {
        string levelName = SceneManager.GetActiveScene().name;
        int loadCheckpoint = PlayerPrefs.GetInt(levelName + "_checkpoints", 0);

        Checkpoint checkpoint = checkpointLocations[loadCheckpoint];
        checkpoint.LoadCheckpoint();
    }


    public void SetCheckpoint(int checkpointIndex)
    {
        string levelName = SceneManager.GetActiveScene().name;

        int lastCheckpoint = PlayerPrefs.GetInt(levelName + "_checkpoints", 0);
        if (lastCheckpoint < checkpointIndex)
        {
            PlayerPrefs.SetInt(levelName + "_checkpoints", checkpointIndex);
        }
    }
}
