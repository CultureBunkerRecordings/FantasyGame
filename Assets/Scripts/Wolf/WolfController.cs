using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
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

    public Enemy wolf;

    // Start is called before the first frame update
    void Start()
    {
        wolf = new Enemy();
        wolf.transform = transform;
        wolf.speed = speed;
        wolf.isMoving = isMoving;
        wolf.attackPoint = attackPoint;
        wolf.playersLayer = playersLayer;
        wolf.attackRange = attackRange;
        wolf.attackingPlayer = attackingPlayer;
        wolf.rb = GetComponent<Rigidbody>();
        wolf.attackCoolDown = attackCoolDown;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            wolf.attack();
        }
    }

    private void LateUpdate()
    {
        wolf.facingRight = facingRight;
        wolf.flip();
    }

}
