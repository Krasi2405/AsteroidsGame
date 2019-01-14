using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    private Asteroid[] asteroidPrefabs;

    [SerializeField]
    private float spawnTime = 1;

    private float lastSpawnDegrees = 0;

    void Start()
    {
        StartCoroutine("SpawnAsteroidLoop");
    }

    IEnumerator SpawnAsteroidLoop()
    {
        while (true)
        {
            Debug.Log("Spawn asteroid!");
            yield return new WaitForSeconds(spawnTime);
            Vector3 position = GetAsteroidSpawnPosition();
            SpawnAsteroid(position);
        }
    }

    Vector3 GetAsteroidSpawnPosition()
    {
        int width = Screen.width;
        int height = Screen.height;

        Vector3 asteroidPositionScreenSpace = new Vector3(width, height, 0);
        Vector3 asteroidPositionWorldSpace = Camera.main.ScreenToWorldPoint(asteroidPositionScreenSpace);

        return asteroidPositionWorldSpace;
    }

    void SpawnAsteroid(Vector3 position)
    {
        int index = Random.Range(0, asteroidPrefabs.Length);
        Asteroid asteroid = Instantiate(asteroidPrefabs[index]);
        asteroid.transform.position = position;
        
        asteroid.transform.RotateAround(Vector3.zero, Vector3.up, GetSpawnDegrees());
        asteroid.SetTarget(FindObjectOfType<PlayerController>().transform.position);
    }

    float GetSpawnDegrees()
    {
        float degrees = Random.Range(0, 360);
        if(SpawnDegreesOverlap(degrees, lastSpawnDegrees))
        {
            return GetSpawnDegrees();
        }

        lastSpawnDegrees = degrees;
        return degrees;
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
}
