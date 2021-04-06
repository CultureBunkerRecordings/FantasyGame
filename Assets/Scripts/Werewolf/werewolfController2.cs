using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class werewolfController2 : MonoBehaviour
{
    public ParticleSystem particles;
    private Animator wereWolfAnim2;
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
        pController = GameObject.Find("Player2Controller").GetComponent<playerController>();
        wereWolfAnim2 = GetComponent<Animator>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //stomp();
        drinkPotion();
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
            wereWolfAnim2.SetTrigger("attack");

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
            wereWolfAnim2.SetBool("stomp", true);
        }
        else
        {
            wereWolfAnim2.SetBool("stomp", false);
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
            wereWolfAnim2.SetBool("walk", true);
        }
        else
        {
            wereWolfAnim2.SetBool("walk", false);
        }
    }

    void JumpingAnim()
    {
        if (pController.isJumping)
        {
            wereWolfAnim2.SetBool("jump", true);
        }
        else
        {
            wereWolfAnim2.SetBool("jump", false);
        }
    }

    void drinkPotion()
    {
        if (pController.isPickingUpRed)
        {
            wereWolfAnim2.SetTrigger("drinkPotion");
        }

    }


    void blueAttack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions > 0)
        {
            wereWolfAnim2.SetTrigger("blueAttack");
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
