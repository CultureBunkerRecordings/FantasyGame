using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyHealth eHealth = collision.gameObject.GetComponent<EnemyHealth>();
            eHealth.takeDamage(3);
            Destroy(gameObject);
        }
    }
}
