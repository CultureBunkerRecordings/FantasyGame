using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellOutOfBounds : MonoBehaviour
{
    float leftBound = -100;
    float rightBound = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
