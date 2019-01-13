using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitting : MonoBehaviour {

    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private float angleRange = 30;

    public void Split()
    {
        SpawnObject(-angleRange);
        SpawnObject(angleRange);
    }

    private void SpawnObject(float angle)
    {
        Debug.Log("Spawn split asteroid!");
        GameObject obj = Instantiate(spawnObject, transform.position, Quaternion.identity);
        
        

        
        if (obj.GetComponent<Asteroid>())
        {
            obj.GetComponent<Asteroid>().SetDirection(Vector3.forward);
        }
    }
}
