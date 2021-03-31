using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject wolfPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnWolf", 2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnWolf()
    {
        Instantiate(wolfPrefab, transform.position, Quaternion.identity);
    }
}
