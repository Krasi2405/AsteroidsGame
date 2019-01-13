using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    private Asteroid[] asteroidPrefabs;

    [SerializeField]
    private float spawnTime = 1;

    [SerializeField]
    private float spawnRandomWidth = 10f;

    [SerializeField]
    private float spawnXRotationForceMax = 0.5f;


    private float lastSpawnWidth = 0;

    void Start()
    {
        StartCoroutine("SpawnAsteroidLoop");
    }

    IEnumerator SpawnAsteroidLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Vector3 position = GetAsteroidSpawnPosition();
            SpawnAsteroid(position);
        }
    }

    Vector3 GetAsteroidSpawnPosition()
    {
        Vector3 asteroidPosition = new Vector3(transform.position.x, 0, transform.position.y);
        float rightWidth;
        do {
            rightWidth = Random.Range(-spawnRandomWidth, spawnRandomWidth);
        } while (lastSpawnWidth >= rightWidth && lastSpawnWidth - 2 < rightWidth ||
                 lastSpawnWidth <= rightWidth && lastSpawnWidth + 2 > rightWidth);

        lastSpawnWidth = rightWidth;

       
        asteroidPosition += transform.right * rightWidth;

        return asteroidPosition;
    }

    void SpawnAsteroid(Vector3 position)
    {
        int index = Random.Range(0, asteroidPrefabs.Length);
        Asteroid asteroid = Instantiate(asteroidPrefabs[index]);
        asteroid.transform.position = position;
        
        asteroid.SetDirection(GetRandomForwardDirection());
    }

    Vector3 GetRandomForwardDirection()
    {
        Vector3 forward = transform.forward;
        forward += transform.right * Random.Range(-spawnXRotationForceMax, spawnXRotationForceMax);
        return forward;
    }

    bool SpawnDegreesOverlap(float degrees, float lastSpawnDegrees)
    {
        float testDegrees = degrees + 10;
        float testTowards = lastSpawnDegrees + 10;

        testDegrees = testDegrees % 360;
        testTowards = testTowards % 360;

        // 10 is degrees that asteroids have to be apart when spawning
        // TODO: perhaps change to SerializeField in future
        if (testDegrees >= testTowards && testDegrees - 10 <= testTowards ||
           testDegrees <= testTowards && testDegrees + 10 >= testTowards)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1f);
        Gizmos.DrawRay(transform.position, transform.forward * 2);
    }
}
