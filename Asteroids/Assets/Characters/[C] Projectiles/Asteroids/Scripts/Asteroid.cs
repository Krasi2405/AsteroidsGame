using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Asteroid : MonoBehaviour {

    [SerializeField]
    ParticleSystem explosionParticles;
    
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float maxRotationalForce = 10;

    [SerializeField]
    private float damage = 20;

    [SerializeField]
    private float splitRange = 30f;

    [SerializeField]
    [Range(0.25f, 0.75f)]
    private float splitScale = 0.5f;

    private Vector3 rotationalForce;

    private Vector3 targetDirection;

    private bool hasSplit = false;

	void Start () {
        GetComponent<Collider>().enabled = false;
        Invoke("EnableCollider", 0.5f);

        Destroy(gameObject, 20f);

        rotationalForce = new Vector3(
           Random.Range(maxRotationalForce / 10, maxRotationalForce),
           Random.Range(maxRotationalForce / 10, maxRotationalForce),
           Random.Range(maxRotationalForce / 10, maxRotationalForce)
        );
    }

	void Update () {
        MoveToTarget();
        ApplyRotationalForce();

        if (GetComponent<Health>().IsDead())
        {
            if (!hasSplit)
            {
                SpawnAsteroid(-splitRange);
                SpawnAsteroid(splitRange);
            }
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 targetDirection)
    {
        this.targetDirection = targetDirection;
    }

    public Vector3 GetDirection()
    {
        return targetDirection;
    }

    public void SetSplit()
    {
        hasSplit = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if(gameObject.tag == collision.gameObject.tag) // other is asteroid.
        {
            Vector3 explosionPosition = (transform.position + collision.transform.position) / 2;
            Destroy(collision.gameObject);
            SpawnOneTimeParticles(explosionParticles, explosionPosition);
        }
        else if(collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<Spaceship>().TakeDamage(damage);

            SpawnOneTimeParticles(explosionParticles, transform.position);
            Destroy(gameObject);
        }
        else if(collision.gameObject.GetComponent<Projectile>())
        {
            if (!hasSplit)
            {
                SpawnAsteroid(-splitRange);
                SpawnAsteroid(splitRange);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        */
        if(collision.gameObject.GetComponent<Health>())
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            if (!hasSplit)
            {
                SpawnAsteroid(-splitRange);
                SpawnAsteroid(splitRange);
            }
            Destroy(gameObject);
        }
    }

    void SpawnOneTimeParticles(ParticleSystem particlesPrefab, Vector3 position)
    {
        ParticleSystem explosion = Instantiate(particlesPrefab, position, Quaternion.identity);
        Destroy(explosion, explosion.time);
    }

    void SpawnAsteroid(float angle)
    {
        Asteroid obj = Instantiate(gameObject, transform.position, transform.rotation).GetComponent<Asteroid>();
        obj.transform.localScale *= splitScale;

        Vector3 direction = GetDirection();
        Vector3 right = Vector3.Cross(direction, Vector3.up);

        direction += right * angle / 90;
        direction.Normalize();
        
        obj.SetDirection(direction);
        obj.SetSplit();
    }
}
