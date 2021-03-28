using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class werewolfController : MonoBehaviour
{
    playerController pController;
    Animator werewolfAnim;

    // Start is called before the first frame update
    void Start()
    {
        werewolfAnim = GetComponent<Animator>();
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        attack();
        jump();
    }

    void jump()
    {
        if (pController.isJumping)
        {
            werewolfAnim.SetBool("jump", true);
        }
        else
        {
            werewolfAnim.SetBool("jump", false);
        }
    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey))
        {
            werewolfAnim.SetTrigger("attack");
        }
    }
}
