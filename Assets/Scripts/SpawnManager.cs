using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wolfPrefab;
    public GameObject spellPrefab;
    public int numWolvesToSpawn = 4;
    int numWolves;
    // Start is called before the first frame update
    void Start()
    {
        spawnWolves(numWolvesToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        nextWave();
    }

    void spawnWolves(int numWolves)
    {
        for(int i = 0; i < numWolves; i++)
        {
            Instantiate(wolfPrefab, transform.position, Quaternion.identity);
        }
    }

    int wolfCount()
    {
        numWolves = GameObject.FindObjectsOfType<WolfController>().Length;
        return numWolves;
    }

    void nextWave()
    {
        if(wolfCount() == 0)
        {
            numWolvesToSpawn++;
            spawnWolves(numWolvesToSpawn);
            Instantiate(spellPrefab, new Vector3(Random.Range(-3, 3), 0, Random.Range(5, 8)), Quaternion.identity);
        }
    }
}
