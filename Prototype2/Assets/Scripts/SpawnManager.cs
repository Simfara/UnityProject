/*
 * CIS 350 
 * Simfara Ranjit
 * Prototype2 
 * This script randomly spawns the animal objects as long as the game is not over
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ATTACH TO EMPTY GAME OBJECT
public class SpawnManager : MonoBehaviour
{
    //set this array of preference in the inspector
    public GameObject[] prefabsToSpawn;

    //variabels for sowan position
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public HealthSystem healthSystem;

    private void Start()
    {
        //get a refernce to tht health system sctipt
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        //add a 3 sec delay before spawn objects

        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            float randomDelay = Random.Range(0.8f, 3.0f);
            yield return new WaitForSeconds(randomDelay);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))

        {
            //SpawnRandomPrefab();
        }
    }

    void SpawnRandomPrefab()
    {
        //pick a random animal
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        //generate a random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        //Spawn our animal
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
