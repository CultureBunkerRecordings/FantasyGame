using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunController : MonoBehaviour
{

    private Animator FaunAnim;
    playerController pController;


    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
        FaunAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FaunAnim.SetBool("hasPotion", pController.isPickingup);
    }

    
}
