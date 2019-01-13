using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateManager : MonoBehaviour {

    LevelManager levelManager;

	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        if(!levelManager)
        {
            levelManager = gameObject.AddComponent<LevelManager>();
        }
	}
	
	public void Lose()
    {
        Invoke("GoToLoseScene", 2);
    }

    public void Win()
    {
        Invoke("GoToNextScene", 2);
    }

    private void GoToNextScene()
    {
        levelManager.GoToNextScene();
    }

    private void GoToLoseScene()
    {
        levelManager.GoToScene("Game Over");
    }
}
