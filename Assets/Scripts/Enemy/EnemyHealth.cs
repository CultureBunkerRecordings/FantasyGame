using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    SpriteRenderer enemyColour;
    public int health = 10;
    float flashTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        enemyColour = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void enemyFlash()
    {
        enemyColour.color = Color.red;
    }

    void enemyFlashBack()
    {
        enemyColour.color = Color.white;
    }

    public void takeDamage()
    {
        health--;
        enemyFlash();
        Invoke("enemyFlashBack", flashTime);
        if (health <= 0)
        {
            Destroy(gameObject.transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}
