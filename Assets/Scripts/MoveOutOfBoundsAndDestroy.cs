using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOutOfBoundsAndDestroy : MonoBehaviour
{
    public float speed = 1;
    Camera mainCamera;
    Vector3 potionBounds;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);

            float maxX = mainCamera.transform.position.x + 5;
            if (transform.position.x > maxX || transform.position.x < -maxX)
            {
                Destroy(gameObject);
            }
        }
       
    }
}
