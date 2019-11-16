using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public float spawnTime = 1.5f;

    public GameObject Boxes;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBoxes", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBoxes()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length); //Sets index of array randomly
        //int objectIndex = Random.Range(0, Boxes.Length);
       // Instantiate(Boxes[objectIndex], SpawnPoints[spawnIndex].position);
    }
}
