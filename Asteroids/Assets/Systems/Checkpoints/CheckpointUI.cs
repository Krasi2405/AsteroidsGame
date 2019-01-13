using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
    public void ResetCheckpoint()
    {
        FindObjectOfType<CheckpointReset>().ResetCheckpoint();
    }

    public void LoadLastLevel()
    {
        FindObjectOfType<LevelManager>().GoToScene(FindObjectOfType<CheckpointReset>().GetLastSceneName());
    }

    private void OnDestroy()
    {
        if(FindObjectOfType<CheckpointReset>())
        {
            Destroy(FindObjectOfType<CheckpointReset>());
        }
    }
}
