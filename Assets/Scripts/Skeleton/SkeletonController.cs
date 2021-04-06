using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public ParticleSystem particles;
    private Animator SkeletonAnim;
    playerController pController;
    GameManager gManager;
    public LayerMask enemyLayer;
    public float attackRadius;
    public Transform attackPoint;

    GameObject spellPrefab;
    bool hasPotion;
    bool hasPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
        SkeletonAnim = GetComponent<Animator>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //stomp();
        drinkRedPotion();
        blueAttack();
        //hasBluePotion();
        walkingAnim();
        JumpingAnim();
        attack();
    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions == 0)
        {
            SkeletonAnim.SetTrigger("attack");

            Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

            foreach (var enemy in enemyHits)
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
            SkeletonAnim.SetBool("stomp", true);
        }
        else
        {
            SkeletonAnim.SetBool("stomp", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void walkingAnim()
    {
        if (pController.isWalkingAcross || pController.isWalkingUp && pController.onGround)
        {
            SkeletonAnim.SetBool("walk", true);
        }
        else
        {
            SkeletonAnim.SetBool("walk", false);
        }
    }

    void JumpingAnim()
    {
        if (pController.isJumping)
        {
            SkeletonAnim.SetBool("jump", true);
        }
        else
        {
            SkeletonAnim.SetBool("jump", false);
        }
    }

    void drinkRedPotion()
    {
        if (pController.isPickingUpRed)
        {
            SkeletonAnim.SetTrigger("drinkPotion");
        }

    }


    void blueAttack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions > 0)
        {
            SkeletonAnim.SetTrigger("blueAttack");
            particles.Play();
            pController.p1Potions--;
            gManager.updateP1Potions(pController.p1Potions);

            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (allEnemies != null)
            {
                foreach (var enemy in allEnemies)
                {
                    Destroy(enemy);
                }
            }
        }

    }
}
