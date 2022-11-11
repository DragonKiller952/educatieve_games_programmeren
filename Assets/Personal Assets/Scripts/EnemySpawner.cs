using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject RedEnemy;
    public GameObject BlueEnemy;
    public GameObject Player;
    public GameObject WaveScreen;
    private int wave = 1;
    public int amount = 5;
    public int distance = 10;
    private int killed = 0;
    private int killValue = 100;
    private bool coroutine_running;


    private string[] positive = new string[] { "Na", "K", "NH4", "Mg", "Al", "Fe", "Zn", "Cu", "Ca", "Ba", "Hg", "Pb", "Ag"};

    private string[] negative = new string[] { "NO3", "CH3COO", "Cl", "Br", "I", "SO4", "F", "S", "OH", "SO3", "CO3", "PO4", "O"};

    void Start()
    {
        coroutine_running = true;
        StartCoroutine(StartWave());
    }

     //Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0 && !coroutine_running)
        {
            wave++;
            amount += 2;

            coroutine_running = true;
            StartCoroutine(StartWave());
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

    IEnumerator StartWave()
    {
        GameObject waveScreen = Instantiate(WaveScreen);
        waveScreen.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Wave " + wave;
        waveScreen.transform.SetParent(Player.transform);
        yield return new WaitForSeconds(5);
        Destroy(waveScreen);
        SpawnWave(amount);
        coroutine_running = false;
    }

    public void AddKill()
    {
        killed++;
    }

    public int GetKillScore() => (killed * killValue);
}
