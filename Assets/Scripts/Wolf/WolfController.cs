using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public float speed = 2f;
    private bool facingRight = false;
    public bool isMoving = false;
    public Transform attackPoint;
    public LayerMask playersLayer;
    public float attackRange;
    public bool attackingPlayer;

    public GameObject player1;
    public GameObject player2;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player1 = GameObject.Find("PlayerController");
        player2 = GameObject.Find("Player2Controller");
    }

    // Update is called once per frame
    void Update()
    {
        attackCheck();
        moveToPlayers();

    }

    private void LateUpdate()
    {
        flip();
    }


    void flip()
    {
        Vector2 scale = transform.localScale;

        if(facingRight && scale.x > 0 || !facingRight && scale.x < 0)
        {
            scale.x *= -1; 
        }

        transform.localScale = scale;
    }

    void attackCheck()
    {
        attackingPlayer = Physics.CheckSphere(attackPoint.position, attackRange, playersLayer);
    }

    void moveToPlayers()
    {
        if(Vector3.Distance(transform.position, player1.transform.position) < Vector3.Distance(transform.position, player2.transform.position))
        {
            Vector3 pointToPlayer1 = (player1.transform.position - transform.position).normalized;
            rb.AddForce(pointToPlayer1 * speed);
            if(pointToPlayer1.x > 0)
            {
                facingRight = true;
                isMoving = true;
            }
            else if(pointToPlayer1.x < 0)
            {
                facingRight = false;
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        else
        {
            Vector3 pointToPlayer2 = (player2.transform.position - transform.position).normalized;
            rb.AddForce(pointToPlayer2 * speed); 

            if(pointToPlayer2.x > 0)
            {
                facingRight = true;
                isMoving = true;
            }
            else if(pointToPlayer2.x < 0)
            {
                facingRight = false;
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
        
    }

}
