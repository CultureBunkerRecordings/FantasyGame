using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float maxX = mainCamera.transform.position.x + 5;
        if (transform.position.x > maxX || transform.position.x < -maxX)
        {
            Destroy(gameObject);
        }
    }
}
