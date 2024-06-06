using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject[] building;
    public Transform buildingLocation;
    void Start()
    {
        buildingLocation = GetComponent<Transform>();
        Instantiate(building[Random.Range(0, 4)], buildingLocation);
        gameObject.tag = "Building";
    }
}