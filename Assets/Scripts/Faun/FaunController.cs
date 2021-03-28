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
            pController.p1Potions--;
            gManager.updateP1Potions(pController.p1Potions);
        }
        else
        {
            FaunAnim.SetBool("blueAttack", false);

        }
    }
}
