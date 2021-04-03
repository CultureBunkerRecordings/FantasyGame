using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wolfPrefab;
    public GameObject redPotionPrefab;
    public GameObject greenPotionPrefab;
    public GameObject bluePotionPrefab;
    public GameObject purplePotionPrefab;
    GameObject chosenPotion;


    public int numWolvesToSpawn = 4;
    int numWolves;
    public enum Potions { redPotion, bluePotion, greenPotion, purplePotion };
    // Start is called before the first frame update
    void Start()
    {
        spawnWolves(numWolvesToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        nextWave();
        randomPotion();
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
            Instantiate(chosenPotion, new Vector3(Random.Range(-3, 3), 0, Random.Range(5, 8)), Quaternion.identity);
        }
    }

    void randomPotion()
    {
        int randomPotion = Random.Range(0, 3);
        switch (randomPotion)
        {
            case 0:
                chosenPotion = redPotionPrefab;
                break;
            case 1:
                chosenPotion = greenPotionPrefab;
                break;
            case 2:
                chosenPotion = bluePotionPrefab;
                break;
            case 3:
                chosenPotion = purplePotionPrefab;
                break;
        }
    }
}
