using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject RedEnemy;
    public GameObject BlueEnemy;
    public GameObject Player;
    private int wave = 1;
    public int amount = 10;
    public int distance = 10;


    private string[] positive = new string[] { "Na", "K", "NH4", "Mg", "Al", "Fe", "Zn", "Cu", "Ca", "Ba", "Hg", "Pb", "Ag"};

    private string[] negative = new string[] { "NO3", "CH3COO", "Cl", "Br", "I", "SO4", "F", "S", "OH", "SO3", "CO3", "PO4", "O"};

    void Start()
    {
        SpawnWave(amount);
    }

     //Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            wave++;
            amount += 5;

            SpawnWave(amount);
        }
    }

    void SpawnWave(int enemyAmount)
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            float angle = Random.Range(-Mathf.PI, Mathf.PI);
            Vector3 spawnPosition = transform.position;
            spawnPosition += new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * distance;

            var lookPos = Player.transform.position - spawnPosition;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            int enemyKind = Random.Range(0, 2);
            if (enemyKind == 0)
            {
                string element = negative[Random.Range(0, negative.Length)];
                GameObject newenemy = Instantiate(RedEnemy, spawnPosition, rotation);
                newenemy.GetComponent<CreatureScript>().player = Player;

                GameObject textObject = newenemy.transform.GetChild(15).gameObject;
                textObject.GetComponent<TextMeshPro>().text = element;

                newenemy.transform.parent = transform;
            }
            else if (enemyKind == 1)
            {
                string element = positive[Random.Range(0, positive.Length)];
                GameObject newenemy = Instantiate(BlueEnemy, spawnPosition, rotation);
                newenemy.GetComponent<CreatureScript>().player = Player;

                GameObject textObject = newenemy.transform.GetChild(15).gameObject;
                textObject.GetComponent<TextMeshPro>().text = element;

                newenemy.transform.parent = transform;
            }
        }
    }
}
