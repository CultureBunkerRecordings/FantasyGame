using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName ="Character")]
public class Characters : ScriptableObject
{
    public ParticleSystem particles;
    public  Animator anim;
    public playerController pController;
    public LayerMask enemyLayer;
    public float attackRadius;
    public Transform attackPoint;

    public GameObject spellPrefab;
    public bool hasPotion;
    public bool hasPickedUp;
    public bool kicking = false;
    // Start is called before the first frame update
   
    public void attack()
    {
        if (Input.GetKeyDown(pController.attackKey) && !Input.GetKeyDown(pController.downKey) && !pController.hasBlue)
        {
            anim.SetBool("attack", true);

            Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

            foreach (var enemy in enemyHits)
            {
                Debug.Log(enemy.name + "Hit");
                enemy.GetComponent<EnemyHealth>().takeDamage();
            }
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }

    public void stomp()
    {
        if (Input.GetKey(pController.downKey) && pController.isJumping)
        {
            anim.SetBool("stomp", true);
        }
        else
        {
            anim.SetBool("stomp", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void walkingAnim()
    {
        if (pController.isWalkingAcross || pController.isWalkingUp && pController.onGround)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    public void JumpingAnim()
    {
        if (pController.isJumping)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }

    public void drinkPotions()
    {
        if (pController.isPickingUpRed)
        {
            anim.SetTrigger("drinkPotionRed");
        }
        else if (pController.isPickingUpBlue)
        {
            anim.SetTrigger("drinkPotionBlue");
        }
        else if (pController.isPickingUpGreen)
        {
            anim.SetTrigger("drinkPotionGreen");
        }
        else if (pController.isPickingUpPurple)
        {
            anim.SetTrigger("drinkPotionPurple");
        }

    }


    public void blueAttack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.hasBlue)
        {
            anim.SetBool("blueAttack", true);
            particles.Play();
            pController.p1Potions--;
            GameManager.SingletonInstance.updateP1Potions(pController.p1Potions);

            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (allEnemies != null)
            {
                foreach (var enemy in allEnemies)
                {
                    Destroy(enemy.transform.parent.gameObject);
                }
            }
            pController.hasBlue = false;
        }
        else
        {
            anim.SetBool("blueAttack", false);
        }

    }

    public void kick()
    {
        if (Input.GetKey(pController.downKey))
        {
            if (Input.GetKeyDown(pController.attackKey))
            {
                pController.kicking = true;

                anim.SetBool("kick", true);

                Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

                foreach (var enemy in enemyHits)
                {
                    Debug.Log(enemy.name + "Hit");
                    enemy.GetComponent<EnemyHealth>().takeDamage();
                }
            }
            else
            {
                anim.SetBool("kick", false);
            }
        }
        else if (Input.GetKeyUp(pController.downKey))
        {
            pController.kicking = false;
        }

    }
}
