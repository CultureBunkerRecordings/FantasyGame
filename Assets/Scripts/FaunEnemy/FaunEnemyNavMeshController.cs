﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FaunEnemyNavMeshController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    FaunEnemyController fController;
    public bool isMoving;

    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        fController = GetComponentInChildren<FaunEnemyController>();
        nav = GetComponent<NavMeshAgent>();
        player1 = GameObject.Find("PlayerController");
        player2 = GameObject.Find("Player2Controller");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {

            nav.SetDestination(player1.transform.position);

            if (nav.pathEndPosition.x < nav.transform.position.x)
            {
                fController.faunEnemy.facingRight = true;
            }
            else
            {
                fController.faunEnemy.facingRight = false;
            }

            if (nav.velocity.magnitude > 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
