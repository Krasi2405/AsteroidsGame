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

    protected virtual void Destruct()
    {
        // Debug.Log("Call destruct on projectile " + name);
    }

    protected abstract void ShootEffect(GameObject gameObj);

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>() && other.tag != parent.tag && other.tag != gameObject.tag)
        {
            Debug.Log("Hit " + other.name);
            ShootEffect(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Application.isPlaying)
        {
            Destruct();
        }
    }
}
