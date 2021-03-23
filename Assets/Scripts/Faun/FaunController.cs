using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunController : MonoBehaviour
{

    private Animator FaunAnim;
    playerController pController;

    public LayerMask enemyLayer;
    public float attackRadius;
    public Transform attackPoint;

    WolfController wolf;


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
        walkingAnim();
        attack();

    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey))
        {
            FaunAnim.SetTrigger("attack");

            Collider2D[] enemyHits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

            foreach(var enemy in enemyHits)
            {
                Debug.Log(enemy.name + "Hit");
                enemy.GetComponent<EnemyHealth>().takeDamage();
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void walkingAnim()
    {
        if (pController.isWalking && pController.onGround)
        {
            FaunAnim.SetBool("walk", true);
        }
        else
        {
            FaunAnim.SetBool("walk", false);
        }
    }

    
}
