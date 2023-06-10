using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerrySpawn : MonoBehaviour
{

    public GameObject[] berries;
    public List<Transform> spawnPoints;

    public void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnBerries();

        //int rand = Random.Range(0, objects.Length);
        //Instantiate(objects[rand], transform.position, Quaternion.identity);

    }

    public void SpawnBerries()
    {

        for ( int i = 0; i < berries.Length; i++)
        {
            var spawn = Random.Range(0, spawnPoints.Count);
            Instantiate(berries[i], spawnPoints[spawn].transform.position, Quaternion.identity);
            spawnPoints.RemoveAt(spawn);
        }
        
    }
}
