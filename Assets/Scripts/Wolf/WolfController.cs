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
    public bool attackingPlayer;

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
        attackCheck();
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

    void attackCheck()
    {
        attackingPlayer = Physics.CheckSphere(attackPoint.position, attackRange, playersLayer);
    }


}
