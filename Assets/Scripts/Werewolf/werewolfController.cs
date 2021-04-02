using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class werewolfController : MonoBehaviour
{
    GameManager gManager;
    playerController pController;
    Animator werewolfAnim;
    
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;

    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        werewolfAnim = GetComponent<Animator>();
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
        jump();
        blueAttack();
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
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions == 0)
        {
            werewolfAnim.SetTrigger("attack");

            Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

            foreach (var enemy in enemyHits)
            {
                Debug.Log(enemy.name + "Hit");
                enemy.GetComponent<EnemyHealth>().takeDamage();
            }
        }

    }

    void blueAttack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions > 0)
        {
            werewolfAnim.SetTrigger("blueAttack");
            particles.Play();
            pController.p1Potions--;
            gManager.updateP1Potions(pController.p1Potions);
        }

    }
}
