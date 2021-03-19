using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var p1Pos = p1.transform.position;
        var p2Pos = p2.transform.position;

        Vector2 midPoint = (p2Pos + p1Pos) * 0.5f;

        transform.position = midPoint;
    }
}
