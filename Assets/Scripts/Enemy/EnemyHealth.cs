using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    SpriteRenderer enemyColour;
    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        enemyColour = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyColour.color = Color.white;
    }

    public void takeDamage()
    {
        health--;
        enemyColour.color = Color.black;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
