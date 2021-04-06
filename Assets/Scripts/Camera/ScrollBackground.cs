using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
            if (transform.position.x < -10.0f)
            {
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        
    }
}
