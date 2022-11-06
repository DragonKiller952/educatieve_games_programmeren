using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{

    public GameObject RedAmmo;
    public GameObject BlueAmmo;
    public int amount = 10;
    public int distance = 5;

    void Start()
    {
        Vector3 spawnArea = new Vector3(distance, 0, distance);

        for (int i = 0; i < amount; i++)
        {
            //float angle = Random.Range(-Mathf.PI, Mathf.PI);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));

            while (Vector3.Distance(spawnPosition, transform.position) > distance)
            {
                spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));
            }

            Quaternion spawnRotation = Quaternion.identity;
            var rotation = Quaternion.identity;


            if (i%2 == 0)
            {
                Instantiate(RedAmmo, spawnPosition, rotation);
            }
            else
            {
                Instantiate(BlueAmmo, spawnPosition, rotation);
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
