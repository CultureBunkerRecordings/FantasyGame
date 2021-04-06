using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject redPotionPrefab;
    public GameObject greenPotionPrefab;
    public GameObject bluePotionPrefab;
    public GameObject purplePotionPrefab;
    GameObject chosenPotion;

    public GameObject wolfArmyPrefab;
    public GameObject shroomArmyPrefab;
    public GameObject ghoulArmyPrefab;
    public GameObject skeletonArmyPrefab;
    GameObject chosenEnemy;

    public GameObject floor;

    public int numEnemiesToSpawn = 4;
    int numEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnEnemy", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        randomPotion();
        randomEnemy();
        nextWave();
    }

    void spawnEnemy(int numEnemies)
    {
        for(int i = 0; i < numEnemies; i++)
        {
            Instantiate(chosenEnemy, transform.position, Quaternion.identity);
        }
    }

    int enemyCount()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        return numEnemies;
    }

    void nextWave()
    {
        if(enemyCount() == 0)
        {
            numEnemiesToSpawn++;
            spawnEnemy(numEnemiesToSpawn);
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

    void randomEnemy()
    {
        int randomEnemy = Random.Range(0, 3);
        switch (randomEnemy)
        {
            case 0:
                chosenEnemy = shroomArmyPrefab;
                break;
            case 1:
                chosenEnemy = ghoulArmyPrefab;
                break;
            case 2:
                chosenEnemy = skeletonArmyPrefab;
                break;
            case 3:
                chosenEnemy = wolfArmyPrefab;
                break;
        }

    }
}
