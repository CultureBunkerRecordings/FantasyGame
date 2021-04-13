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

    public Enemy faunEnemy;

    // Start is called before the first frame update
    void Start()
    {
        faunEnemy = new Enemy();
        faunEnemy.transform = transform;
        faunEnemy.speed = speed;
        faunEnemy.facingRight = facingRight;
        faunEnemy.isMoving = isMoving;
        faunEnemy.attackPoint = attackPoint;
        faunEnemy.playersLayer = playersLayer;
        faunEnemy.attackRange = attackRange;
        faunEnemy.attackingPlayer = attackingPlayer;
        faunEnemy.rb = GetComponent<Rigidbody>();
        faunEnemy.attackCoolDown = attackCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            faunEnemy.attack();
        }
    }

    private void LateUpdate()
    {
        faunEnemy.flip();
    }

}
