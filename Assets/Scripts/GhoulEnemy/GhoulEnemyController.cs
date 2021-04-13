using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulEnemyController : MonoBehaviour
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

    public Enemy ghoulEnemy;

    // Start is called before the first frame update
    void Start()
    {
        ghoulEnemy = new Enemy();
        ghoulEnemy.transform = transform;
        ghoulEnemy.speed = speed;
        ghoulEnemy.facingRight = facingRight;
        ghoulEnemy.isMoving = isMoving;
        ghoulEnemy.attackPoint = attackPoint;
        ghoulEnemy.playersLayer = playersLayer;
        ghoulEnemy.attackRange = attackRange;
        ghoulEnemy.attackingPlayer = attackingPlayer;
        ghoulEnemy.rb = GetComponent<Rigidbody>();
        ghoulEnemy.attackCoolDown = attackCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            ghoulEnemy.attack();
        }
    }

    private void LateUpdate()
    {
        ghoulEnemy.flip();
    }
}
