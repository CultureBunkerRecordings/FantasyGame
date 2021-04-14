using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public bool facingRight = false;
    public bool isMoving = false;
    public Transform attackPoint;
    public LayerMask playersLayer;
    public float attackRange;
    public bool attackingPlayer = false;

    int p1Health;
    int p2Health;
    float attackCoolDown = 1;

    Rigidbody rb;
    
    public float jumpPower;
    float lastJumpTime = 0;
    float jumpTimer = 2.0f;


    public Enemy faunEnemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        faunEnemy = new Enemy();
        faunEnemy.transform = transform;
        faunEnemy.speed = speed;
        faunEnemy.facingRight = facingRight;
        faunEnemy.isMoving = isMoving;
        faunEnemy.attackPoint = attackPoint;
        faunEnemy.playersLayer = playersLayer;
        faunEnemy.attackRange = attackRange;
        faunEnemy.attackingPlayer = attackingPlayer;
        faunEnemy.rb = rb;
        faunEnemy.attackCoolDown = attackCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            faunEnemy.attack();
            jump();
        }
    }

    private void LateUpdate()
    {
        faunEnemy.flip();
    }

    void jump()
    {

        if (lastJumpTime > jumpTimer && isMoving)
        {
            rb.AddForce(jumpPower * Vector3.up);
            lastJumpTime = 0;
        }
        lastJumpTime += Time.deltaTime;

    }

}
