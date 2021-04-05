﻿using System.Collections;
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

    GameManager gManager;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.gamePlaying)
        {
            attack();
        }
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


    void attack()
    {
        if (attackCoolDown <= 0)
        {
            Collider[] players =  Physics.OverlapSphere(attackPoint.position, attackRange, playersLayer);
            foreach (var player in players)
            {
                if (player.name == "PlayerController")
                {
                    p1Health = --player.GetComponent<playerController>().health1;
                    gManager.updateP1Health(p1Health);
                    Debug.Log("hit");
                }
                else
                {
                    p2Health = --player.GetComponent<playerController>().health2;
                    gManager.updateP2Health(p2Health);
                }
            }
            attackingPlayer = true;
            attackCoolDown = 1;
        }
        else
        {
            attackingPlayer = false;
        }

        attackCoolDown -= Time.deltaTime;
    }

}
