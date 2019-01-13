using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float timeToLive = 20f;

    [SerializeField]
    private GameObject parent;

    [SerializeField]
    private string parentTag;

    private Vector3 target;
    
	void Start () {
        Destroy(gameObject, timeToLive);

        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
    }
    
    void LateUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void SetParent(GameObject parent)
    {
        this.parent = parent;
        parentTag = parent.tag;
    }

    public GameObject GetParent()
    {
        return parent;
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
        gameObject.transform.LookAt(transform.position + target.normalized);
    }

    protected virtual void Destruct()
    {
        // Debug.Log("Call destruct on projectile " + name);
    }

    protected abstract void ShootEffect(GameObject gameObj);

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject && other.GetComponent<Health>() && other.tag != parentTag && other.tag != gameObject.tag)
        {
            ShootEffect(other.gameObject);
            Destruct();
        }
    }
}
