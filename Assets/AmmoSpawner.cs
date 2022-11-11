using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AmmoSpawner : MonoBehaviour
{

    public GameObject RedAmmo;
    public GameObject BlueAmmo;
    public int distance = 5;
    private float spawnTime;
    private float spawnDelay = 30f;
    private int spawned;
    private int pickedUp = 0;
    private int pickedUpValue = 10;

    void Start()
    {
        spawnTime = Time.time + spawnDelay;
        spawned = transform.childCount;
    }

    //Update is called once per frame
    void Update()
    {
        if (transform.childCount < spawned)
        {
            pickedUp += (spawned - transform.childCount);
        }

        if (spawnTime <= Time.time)
        {
            spawnTime = Time.time + spawnDelay;
            SpawnAmmo();
        }
        spawned = transform.childCount;

    }

    void SpawnAmmo()
    {
        Vector3 spawnArea = new Vector3(distance, 0, distance);

        for (int i = 0; i < 2; i++)
        {
            //float angle = Random.Range(-Mathf.PI, Mathf.PI);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));

            while (Vector3.Distance(spawnPosition, transform.position) > distance)
            {
                spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));
            }

            Quaternion spawnRotation = Quaternion.identity;
            var rotation = Quaternion.identity;


            if (i % 2 == 0)
            {
                GameObject red = Instantiate(RedAmmo, spawnPosition, rotation);
                red.transform.parent = transform;
            }
            else
            {
                GameObject blue = Instantiate(BlueAmmo, spawnPosition, rotation);
                blue.transform.parent = transform;
            }
        }
    }

    public int GetPickUpScore() => (pickedUp * pickedUpValue);
}
