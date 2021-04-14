using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhoulEnemyNavMeshController : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    GhoulEnemyController gController;
    public bool isMoving;

    int index;
    public float patrolTime = 2;
    public float aggroRange;
    public GameObject[] waypoints;

    NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        gController = GetComponentInChildren<GhoulEnemyController>();
        nav = GetComponent<NavMeshAgent>();
        player1 = GameObject.Find("PlayerController");
        player2 = GameObject.Find("Player2Controller");

        index = Random.Range(0, waypoints.Length);
        waypoints = GameObject.FindGameObjectsWithTag("leftWayPoints");

        InvokeRepeating("ticks", 0, 0.5f);

        if (waypoints != null)
        {
            InvokeRepeating("patrol", Random.Range(0, patrolTime), patrolTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.SingletonInstance.gamePlaying)
        {
            if (nav.pathEndPosition.x < nav.transform.position.x)
            {
                gController.ghoulEnemy.facingRight = true;
            }
            else
            {
                gController.ghoulEnemy.facingRight = false;
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

    void patrol()
    {
        index = index == waypoints.Length - 1 ? 0 : index + 1;
    }

    void ticks()
    {
        if (player1 != null && Vector3.Distance(transform.position, player1.transform.position) < aggroRange)
        {
            Vector3 target = new Vector3(transform.position.x, transform.position.y, player1.transform.position.z);

            nav.SetDestination(target);
        }
        else
        {
            nav.SetDestination(waypoints[index].transform.position);
        }
    }
}
