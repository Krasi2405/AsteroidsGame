using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [SerializeField]
    private Asteroid[] asteroidPrefabs;

    [SerializeField]
    private float spawnTime = 1;

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

        float degrees = Random.Range(0, 360);
        asteroid.transform.RotateAround(Vector3.zero, Vector3.up, degrees);
    }
}
