using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {
    
	void Start () {
	    	
	}

	
	void Update () {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if(viewportPos.x >= 1)
        {
            Debug.Log("Wrap X > 1");
            viewportPos.x -= 1.05f;
        }

        if(viewportPos.x <= 0)
        {
            Debug.Log("Wrap X < 0");
            viewportPos.x += 1.05f;
        }

        if(viewportPos.y >= 1)
        {
            Debug.Log("WRAP Y > 1");
            viewportPos.y -= 1.05f;
        }

        if(viewportPos.y <= 0)
        {
            Debug.Log("WRAP Y < 0");
            viewportPos.y += 1.05f;
        }
        
        transform.position = Camera.main.ViewportToWorldPoint(viewportPos);
    }
}
