using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FaunEnemyNavMeshController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    public GameObject[] waypoints;

    FaunEnemyController fController;
    public bool isMoving;

    float patrolTime = 5;
    float aggroRange = 2;
    int index;

    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        fController = GetComponentInChildren<FaunEnemyController>();
        nav = GetComponent<NavMeshAgent>();
        player1 = GameObject.Find("PlayerController");
        player2 = GameObject.Find("Player2Controller");
        index = Random.Range(0, waypoints.Length);
        waypoints = GameObject.FindGameObjectsWithTag("wayPoints");

        InvokeRepeating("ticks", 0, 0.5f);

        if(waypoints != null)
        {
            InvokeRepeating("patrol", Random.Range(0, patrolTime), patrolTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
    void patrol()
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;
    }

    void ticks()
    {   
        if(player1!= null && Vector3.Distance(transform.position, player1.transform.position) < aggroRange)
        {
            nav.SetDestination(player1.transform.position);
        }
        else
        {
            nav.SetDestination(waypoints[index].transform.position);
        }
    }
}
