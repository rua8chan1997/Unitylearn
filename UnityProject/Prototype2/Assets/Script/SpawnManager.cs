using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    // Spawn top animal
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    // Spawn left, right animal
    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;

    // Delay spawn
    private float startDelay = 2f;
    /*private float spawnInterval = 1.5f;*/
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, Random.Range(2,4));
        InvokeRepeating("SpawnLeftAnimal", startDelay, Random.Range(2, 4));
        InvokeRepeating("SpawnRightAnimal", startDelay, Random.Range(2, 4));
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void SpawnRandomAnimal()
    {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ,sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

    void SpawnRightAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ,sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation));
    }

}
