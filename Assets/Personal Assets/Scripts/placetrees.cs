using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class placetrees : MonoBehaviour
{ 
    public GameObject[] prefabs = {};
    public GameObject forest;
    public int amount;
    public int distance = 17;
    // Start is called before the first frame update

    void Start()
    {
        Vector3 spawnArea = new Vector3(30, 0, 30);
        int trees = 0;
        
        for (int i = 0; i < amount; i++)
        {
            int treekind = Random.Range(0, prefabs.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));
            //while (Vector3.Distance(spawnPosition, transform.position) < distance || Physics.CheckSphere(spawnPosition, 2f))
            //{
            //    spawnPosition = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), spawnArea.y, Random.Range(-spawnArea.z, spawnArea.z));
            //}
            //Instantiate(prefabs[treekind], spawnPosition, Random.rotation);
            if (Vector3.Distance(spawnPosition, transform.position) > distance && Physics.OverlapSphere(spawnPosition, 0.8f).Length == 1)
            {
                Quaternion rotation = Quaternion.identity;
                rotation.y = Random.rotation.y;
                GameObject tree = Instantiate(prefabs[treekind], spawnPosition, rotation);
                tree.transform.parent = forest.transform;
                trees++;
            }
        }
        Debug.Log(trees + " trees planted");
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
