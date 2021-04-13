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
        wController = GetComponent<WolfController>();
        wolfAnim = GetComponent<Animator>();
        wNav = GetComponentInParent<WolfNavMeshController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
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
        if (wController.wolf.attackingPlayer)
        {
            wolfAnim.SetTrigger("howl");
        }
    }

}
