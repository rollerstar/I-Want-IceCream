using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    int buildingType, newBuildingType;
    public GameObject[] Shop, Building;

    private void Start()
    {
        SpawnNewBuilding();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SpawnNewBuilding();
        }
    }
    void SpawnNewBuilding()
    {
        BuildingType();
        SpawnBuilding();
    }

    void BuildingType()
    {
        if (buildingType == 1)
        {
            newBuildingType = 0;
        }
        else if (buildingType == 0)
        {
            newBuildingType = Random.Range(0, 1);
        }
    }

    void SpawnBuilding()
    {
        if (buildingType == 1)
        {
            Instantiate(Shop[Random.Range(0, 5)], transform.position, transform.rotation);
        }
        else
        {
            Instantiate(Building[Random.Range(0, 4)], transform.position, transform.rotation);
        }
    }

    public void SetShop()
    {
        buildingType = 1;
    }

    public void SetBuilding()
    {
        buildingType = 0;
    }
}