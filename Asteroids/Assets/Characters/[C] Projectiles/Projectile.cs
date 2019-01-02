using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float timeToLive = 20f;

    [SerializeField]
    private GameObject parent;

    public void SetParent(GameObject parent)
    {
        this.parent = parent;
    }

	void Start () {
        Destroy(gameObject, timeToLive);
        GetComponent<Rigidbody>().AddForce(parent.transform.forward * speed);
        gameObject.transform.LookAt(parent.transform.position + parent.transform.forward);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
