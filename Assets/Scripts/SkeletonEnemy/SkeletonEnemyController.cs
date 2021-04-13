using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemyController : MonoBehaviour
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

    public Enemy skeletonEnemy;

    // Start is called before the first frame update
    void Start()
    {
        skeletonEnemy = new Enemy();
        skeletonEnemy.transform = transform;
        skeletonEnemy.speed = speed;
        skeletonEnemy.facingRight = facingRight;
        skeletonEnemy.isMoving = isMoving;
        skeletonEnemy.attackPoint = attackPoint;
        skeletonEnemy.playersLayer = playersLayer;
        skeletonEnemy.attackRange = attackRange;
        skeletonEnemy.attackingPlayer = attackingPlayer;
        skeletonEnemy.rb = GetComponent<Rigidbody>();
        skeletonEnemy.attackCoolDown = attackCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            skeletonEnemy.attack();
        }
    }

    private void LateUpdate()
    {
        skeletonEnemy.flip();
    }
}
