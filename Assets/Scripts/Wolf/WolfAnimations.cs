using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimations : MonoBehaviour
{
    WolfController wController;
    Animator wolfAnim;
    // Start is called before the first frame update
    void Start()
    {
        wController = GetComponent<WolfController>();
        wolfAnim = GetComponent<Animator>();
        StartCoroutine("howlCoRoutine");
    }

    // Update is called once per frame
    void Update()
    {
        howlAnim();
        runAnim();
    }

    void runAnim()
    {
        if(wController.isMoving)
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
        if (wController.hasSeenPlayer)
        {
            wolfAnim.SetTrigger("howl");
        }
    }

    IEnumerator howlCoRoutine()
    {
        howlAnim();
        yield return new WaitForSeconds(0.5f);
    }

}
