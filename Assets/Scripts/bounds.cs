using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds : MonoBehaviour
{
    public Camera cam;
    // Use this for initialization
    
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var dist = (this.transform.position - Camera.main.transform.position).z;

        var leftBorder = cam.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = cam.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var topBorder = cam.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var bottomBorder = cam.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        Vector3 playerSize = GetComponent<Collider>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 2, rightBorder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 2, bottomBorder - playerSize.y / 2),
        this.transform.position.z
        );

    }
}
