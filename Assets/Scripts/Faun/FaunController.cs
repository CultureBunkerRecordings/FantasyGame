using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunController : MonoBehaviour
{

    private Animator FaunAnim;
    playerController pController;
    GameManager gManager;
    public LayerMask enemyLayer;
    public float attackRadius;
    public Transform attackPoint;
    WolfController wolf;

    GameObject spellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
        FaunAnim = GetComponent<Animator>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        stomp();
        blueAttack();
        hasBluePotion();
        walkingAnim();
        JumpingAnim();
        attack();
        drinkPotion();
    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions<1)
        {
            FaunAnim.SetTrigger("attack");

            Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

            foreach(var enemy in enemyHits)
            {
                Debug.Log(enemy.name + "Hit");
                enemy.GetComponent<EnemyHealth>().takeDamage();
            }
        }

    }

    void stomp()
    {
        if (Input.GetKey(pController.downKey) && pController.isJumping)
        {
            FaunAnim.SetBool("stomp", true);
        }
        else
        {
            FaunAnim.SetBool("stomp", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void walkingAnim()
    {
        if (pController.isWalkingAcross && pController.isWalkingUp && pController.onGround)
        {
            FaunAnim.SetBool("walk", true);
        }
        else
        {
            FaunAnim.SetBool("walk", false);
        }
    }

    void JumpingAnim()
    {
        if (pController.isJumping)
        {
            FaunAnim.SetBool("jump", true);
        }
        else
        {
            FaunAnim.SetBool("jump", false);
        }
    }
    
    void drinkPotion()
    {
        FaunAnim.SetBool("hasPotion", pController.isPickingup);
    }

    void hasBluePotion()
    {
        if (pController.p1Potions > 0 && pController.isPickingup)
        {
            FaunAnim.SetTrigger("hasBluePotion");
        }
    }

    void blueAttack()
    {
        if(Input.GetKeyDown(pController.attackKey))
        {
            FaunAnim.SetBool("blueAttack", true);
            
            if(pController.p1Potions > 0)
            {
                pController.p1Potions--;
            }

            gManager.updateP1Potions(pController.p1Potions);
        }
        else
        {
            FaunAnim.SetBool("blueAttack", false);

        }
    }
}
