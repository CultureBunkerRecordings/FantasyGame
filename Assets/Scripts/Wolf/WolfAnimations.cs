using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimations : MonoBehaviour
{
    WolfController wController;
    WolfNavMeshController wNav;
    Animator wolfAnim;
    GameManager gManager;
    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        wController = GetComponent<WolfController>();
        wolfAnim = GetComponent<Animator>();
        wNav = GetComponentInParent<WolfNavMeshController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.gamePlaying)
        {
            howlAnim();
            runAnim();
        }
       
    }

    void runAnim()
    {
        if(wNav.isMoving)
        {
            wolfAnim.SetBool("running", true);
        }
        else
        {
            wolfAnim.SetBool("running", false);
        }
    }

    void howlAnim()
    {
        if (wController.attackingPlayer)
        {
            wolfAnim.SetTrigger("howl");
        }
    }

}
