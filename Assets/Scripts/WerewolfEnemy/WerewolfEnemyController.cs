using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfEnemyController : MonoBehaviour
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

    public Enemy werewolfEnemy;

    // Start is called before the first frame update
    void Start()
    {
        werewolfEnemy = new Enemy();
        werewolfEnemy.transform = transform;
        werewolfEnemy.speed = speed;
        werewolfEnemy.facingRight = facingRight;
        werewolfEnemy.isMoving = isMoving;
        werewolfEnemy.attackPoint = attackPoint;
        werewolfEnemy.playersLayer = playersLayer;
        werewolfEnemy.attackRange = attackRange;
        werewolfEnemy.attackingPlayer = attackingPlayer;
        werewolfEnemy.rb = GetComponent<Rigidbody>();
        werewolfEnemy.attackCoolDown = attackCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            werewolfEnemy.attack();
        }
    }

    private void LateUpdate()
    {
        werewolfEnemy.flip();
    }
}
