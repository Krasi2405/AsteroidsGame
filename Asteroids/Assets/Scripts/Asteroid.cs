using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    ParticleSystem explosionParticles;
    
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float maxRotationalForce = 10;

    [SerializeField]
    private float damage = 20;

    private Vector3 rotationalForce;

    private Vector3 targetDirection;

	void Start () {
        GetComponent<Collider>().enabled = false;
        Invoke("EnableCollider", 0.4f);


        rotationalForce = new Vector3(
           Random.Range(maxRotationalForce / 10, maxRotationalForce),
           Random.Range(maxRotationalForce / 10, maxRotationalForce),
           Random.Range(maxRotationalForce / 10, maxRotationalForce)
        );
    }

    public void SetTarget(Vector3 targetPosition)
    {
        // TODO: This is just a quickfix for a bigger problem with asteroid spawner.
        // FIX LATER
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;

        transform.LookAt(targetPosition);
        targetDirection = transform.forward;
    }
	

	void Update () {
        MoveToTarget();
        ApplyRotationalForce();
	}

    public Vector3 GetDirection()
    {
        return targetDirection;
    }

    private void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }


    private void MoveToTarget() {
        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
    }

    private void ApplyRotationalForce()
    {
        transform.Rotate(rotationalForce * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(gameObject.tag == collision.gameObject.tag) // other is asteroid.
        {
            Vector3 explosionPosition = (transform.position + collision.transform.position) / 2;
            Destroy(collision.gameObject);
            SpawnOneTimeParticles(explosionParticles, explosionPosition);
        }
        else if(collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);

            SpawnOneTimeParticles(explosionParticles, transform.position);
            Destroy(gameObject);
        }
        else if(collision.gameObject.GetComponent<Projectile>())
        {
            if (GetComponent<Splitting>())
            {
                GetComponent<Splitting>().Split();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);

            FindObjectOfType<Score>().AddScore(100); // TODO: SerializeField this.
        }
    }

    void SpawnOneTimeParticles(ParticleSystem particlesPrefab, Vector3 position)
    {
        ParticleSystem explosion = Instantiate(particlesPrefab, position, Quaternion.identity);
        Destroy(explosion, explosion.time);
    }
}
