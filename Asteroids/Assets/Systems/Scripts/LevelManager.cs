using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GoToNextScene()
    {
        int next_level = SceneManager.GetActiveScene().buildIndex + 1;
        GoToScene(next_level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

	void Start () {
		
	}
	
	void Update () {
		
	}
}
