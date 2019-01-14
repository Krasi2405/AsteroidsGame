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

        transform.LookAt(transform.GetComponent<Asteroid>().GetDirection());
        Vector3 rotation = transform.localRotation.eulerAngles;
        Debug.Log("old rotation: " + rotation);
        rotation.y += angle;
        Debug.Log("new rotation: " + rotation);
        obj.transform.eulerAngles = rotation;
        

        if (obj.GetComponent<Asteroid>())
        {
            obj.GetComponent<Asteroid>().SetTarget(obj.transform.position + obj.transform.forward);
        }
    }
}
