using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunController : MonoBehaviour
{

    private Animator FaunAnim;
    // Start is called before the first frame update
    void Start()
    {
        FaunAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pickups")
        {
            FaunAnim.SetBool("hasPotion", true);
        }
        else
        {
            FaunAnim.SetBool("hasPotion", false);
        }
    }
}
