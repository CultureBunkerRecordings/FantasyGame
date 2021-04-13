using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewEnemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public float speed = 2f;
    public bool facingRight;
    public bool isMoving = false;
    public Transform attackPoint;
    public LayerMask playersLayer;
    public float attackRange;
    public bool attackingPlayer = false;
    public float attackCoolDown = 1;
    public Transform transform;
    
    int p1Health;
    int p2Health;
    

    public Rigidbody rb;

    public void flip()
    {
        if(transform!= null)
        {
            Vector2 scale = transform.localScale;

            if (facingRight && scale.x > 0 || !facingRight && scale.x < 0)
            {
                scale.x *= -1;
            }

            transform.localScale = scale;
        }
        
    }


    public void attack()
    {
        if(attackPoint != null)
        {
            if (attackCoolDown <= 0)
            {
                Collider[] players = Physics.OverlapSphere(attackPoint.position, attackRange, playersLayer);
                foreach (var player in players)
                {
                    if (player.name == "PlayerController")
                    {
                        p1Health = --player.GetComponent<playerController>().health1;
                        GameManager.SingletonInstance.updateP1Health(p1Health);
                        Debug.Log("hit");
                    }
                    else if (player.name == "Player2Controller")
                    {
                        p2Health = --player.GetComponent<playerController>().health2;
                        GameManager.SingletonInstance.updateP2Health(p2Health);
                    }
                }
                attackingPlayer = true;
                attackCoolDown = Random.Range(0.5f, 2);
            }
            else
            {
                attackingPlayer = false;
            }

            attackCoolDown -= Time.deltaTime;
        }

    }

        

}
