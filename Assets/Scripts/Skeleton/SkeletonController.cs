using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    playerController pController;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayer;

    Animator skeletonAnim;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnim = GetComponent<Animator>();
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        jump();
    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey))
        {
            skeletonAnim.SetTrigger("attack");
            Collider2D[] enemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            foreach(var enemy in enemys)
            {
                Debug.Log(enemy.name + "Hit");
                enemy.GetComponent<EnemyHealth>().takeDamage();
            }
        }
    }

    void jump()
    {
        if (pController.isJumping)
        {
            skeletonAnim.SetBool("jump", true);
        }
        else
        {
            skeletonAnim.SetBool("jump", false);
        }
    }
}
