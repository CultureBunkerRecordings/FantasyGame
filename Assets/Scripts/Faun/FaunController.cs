using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunController : MonoBehaviour
{
    public ParticleSystem particles;
    private Animator FaunAnim;
    playerController pController;
    GameManager gManager;
    public LayerMask enemyLayer;
    public float attackRadius;
    public Transform attackPoint;

    GameObject spellPrefab;
    bool hasPotion;
    bool hasPickedUp;
    bool kicking = false;
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
        //stomp();
        drinkPotion();
        blueAttack();
        //hasBluePotion();
        kick();
        walkingAnim();
        JumpingAnim();
        attack();
        
    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions == 0 && !Input.GetKeyDown(pController.downKey))
        {
             FaunAnim.SetBool("attack", true);

            Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

            foreach(var enemy in enemyHits)
            {
                Debug.Log(enemy.name + "Hit");
                enemy.GetComponent<EnemyHealth>().takeDamage();
            }
        }
        else
        {
            FaunAnim.SetBool("attack", false);
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
        if (pController.isWalkingAcross || pController.isWalkingUp && pController.onGround)
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
        if (pController.isPickingup)
        {
            FaunAnim.SetTrigger("drinkPotion");
        }

    }


    void blueAttack()
    {
        if(Input.GetKeyDown(pController.attackKey) && pController.p1Potions > 0)
        {
            FaunAnim.SetTrigger("blueAttack");
            particles.Play();
            pController.p1Potions--;
            gManager.updateP1Potions(pController.p1Potions);
            
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(allEnemies != null)
            {
                foreach(var enemy in allEnemies)
                {
                    Destroy(enemy.transform.parent.gameObject);
                }
            }
        }

    }

    void kick()
    {
        if (Input.GetKey(pController.downKey))
        {
            if (Input.GetKeyDown(pController.attackKey))
            {
                pController.kicking = true;

                FaunAnim.SetBool("kick", true);

                Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

                foreach (var enemy in enemyHits)
                {
                    Debug.Log(enemy.name + "Hit");
                    enemy.GetComponent<EnemyHealth>().takeDamage();
                }
            }
            else
            {
                FaunAnim.SetBool("kick", false);
            }
        }
        else if (Input.GetKeyUp(pController.downKey))
        {
            pController.kicking = false;
        }

    }

}
