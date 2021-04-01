using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfNavMeshController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    WolfController wController;
    public bool isMoving;
    GameManager gManager;

    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        wController = GetComponentInChildren<WolfController>();
        nav = GetComponent<NavMeshAgent>();
        player1 = GameObject.Find("PlayerController");
        player2 = GameObject.Find("Player2Controller");
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.gamePlaying)
        {

            nav.SetDestination(player1.transform.position);

            if (nav.pathEndPosition.x > nav.transform.position.x)
            {
                wController.facingRight = true;
            }
            else
            {
                wController.facingRight = false;
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
