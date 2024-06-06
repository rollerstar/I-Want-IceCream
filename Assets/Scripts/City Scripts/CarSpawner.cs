using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public float spawnRate, minSpawnRate, maxSpawnRate;
    public GameObject[] car;
    public Transform spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCar());
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(car[Random.Range(0, 1)], transform.position, transform.rotation);
    }

    IEnumerator SpawnCar()
    {
        yield return new WaitForSeconds(spawnRate);
        Spawn();
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        StartCoroutine(SpawnCar());
    }
}
