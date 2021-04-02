using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShroomNavMeshController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    ShroomController sController;
    public bool isMoving;
    GameManager gManager;

    public NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        sController = GetComponentInChildren<ShroomController>();
        nav = GetComponent<NavMeshAgent>();
        player1 = GameObject.Find("PlayerController");
        player2 = GameObject.Find("Player2Controller");
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.gamePlaying)
        {
            nav.SetDestination(player1.transform.position);

            if (nav.pathEndPosition.x > nav.transform.position.x)
            {
                sController.facingRight = true;
            }
            else
            {
                sController.facingRight = false;
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
