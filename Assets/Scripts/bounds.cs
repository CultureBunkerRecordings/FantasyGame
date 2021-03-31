using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour
{
    public GameObject floor;
    float xBounds;
  
    float xPlayer;
    // Use this for initialization
    
    void Start()
    {
        xBounds = floor.GetComponent<Collider>().bounds.extents.x;
        xPlayer = GetComponent<Collider>().bounds.extents.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xBounds + xPlayer, xBounds - xPlayer),transform.position.y, transform.position.z);
        
    }
}
