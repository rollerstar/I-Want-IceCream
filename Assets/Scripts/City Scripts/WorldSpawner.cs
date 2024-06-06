using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] buildingLocation;
    [SerializeField]
    GameObject[] ShopPrefab;
    public int numStores, counter;
    int StoreLocation;
    [SerializeField]
    GameManager gameManager;
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameManager.totalIceCreams = numStores;
    }

    void Update()
    {
        if (numStores > counter)
        {
            GenerateStores();
        }
    }

    void GenerateStores()
    {
        StoreLocation = Random.Range(0, 63);

        if (buildingLocation[StoreLocation].tag == "Building")
        {
            Destroy(buildingLocation[StoreLocation].transform.GetChild(0).gameObject);
            Instantiate(ShopPrefab[Random.Range(0, 5)], buildingLocation[StoreLocation].transform);
            buildingLocation[StoreLocation].tag = "Store";
            counter++;
        }
    }
}