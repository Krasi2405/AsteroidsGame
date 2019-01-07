using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float damage = 5;

    [SerializeField]
    private float timeToLive = 20f;

    [SerializeField]
    private GameObject parent;

    private Vector3 target;
    
	void Start () {
        Destroy(gameObject, timeToLive);
    }
    
    void LateUpdate()
    {
        transform.position += target.normalized * speed * Time.deltaTime;
    }

    public void SetParent(GameObject parent)
    {
        this.parent = parent;
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
        gameObject.transform.LookAt(transform.position + target.normalized);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
