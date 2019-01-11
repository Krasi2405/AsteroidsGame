using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField]
    private Building[] buildingPrefabs;

    [SerializeField]
    private Location[] buildingRowLocations;

    [SerializeField]
    private int rowBuildingCount = 10;

    [SerializeField]
    private float buildingSpace = 5;

    void Start()
    {
        foreach(Location row in buildingRowLocations)
        {
            SpawnBuildingRow(row.GetLocation(), row.GetForwardDirection(), rowBuildingCount);
        }   
    }


    private void SpawnBuildingRow(Vector3 start, Vector3 direction, int buildingCount)
    {
        Quaternion lookAtRotation = Quaternion.LookRotation((transform.position - start));
        for(int i = 0; i < buildingCount; i++)
        {
            Building buildingPrefab = buildingPrefabs[Random.Range(0, buildingPrefabs.Length - 1)];

            Vector3 position = start + direction * i * buildingSpace;
            Building building = Instantiate(
                buildingPrefab,
                position,
                lookAtRotation
            );
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Location location in buildingRowLocations)
        {
            Vector3 position = location.GetLocation();
            for (int i = 1; i < rowBuildingCount; i++)
            {
                Gizmos.DrawSphere(position, 1f);
                position += location.GetForwardDirection() * buildingSpace;
            }
        }
    }


}
