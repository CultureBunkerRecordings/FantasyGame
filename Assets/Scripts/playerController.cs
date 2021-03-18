using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    GameManager gameManager;

    public GameObject DialogueManager;
    DialogueManager dManager = default;
    DialogueTrigger dTrigger;

    bool isInDialogue = false;

    public float speed = 5;
    public float jumpForce;

    private float x = 0;
    private float y;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public bool facingRight = true;
    
    private bool onGround = false;
    private bool onWall = false;
    public Transform GroundCheck;
    public Transform WallCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;



    public int pickups = 0;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager != null) //check incase there is no DialogueManager in scene
        {
            dManager = DialogueManager.GetComponent<DialogueManager>();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InDialogue();
            }
            isInDialogue = dManager.inDialogue;
        }

        if (gameManager.gamePlaying && !isInDialogue)
        {
            groundCheck();
            wallCheck();
            jumping();
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.gamePlaying)
        {
            movement();
        }
    }

    private void LateUpdate()
    {
        flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pickups")
        {
            Destroy(collision.gameObject);
            pickups = gameManager.score;
            pickups++;
            gameManager.updateScore(pickups);
        }

    }

    void wallCheck()
    {
        onWall = Physics2D.OverlapCircle(WallCheck.position, checkRadius, WhatIsGround);
    }

    void groundCheck()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, WhatIsGround);
    }

    private void jumping()
    {
        if (Input.GetKeyDown(jumpKey) && (onGround == true || onWall == true))            // jump
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void movement()
    {
        if (Input.GetKey(rightKey))
        {
            x = 1;
        }
        else if(Input.GetKey(leftKey))
        {
            x = -1;
        }
        else
        {
            x = 0;
        }
                                 //move left and right
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    private void flip()
    {
        Vector2 scale = transform.localScale;                       //flip sprite when moving the other way

        if (x > 0)
        {
            facingRight = true;
        }
        else if (x < 0)
        {
            facingRight = false;
        }

        if ((facingRight && scale.x < 0) || (!facingRight && scale.x > 0))
        {
            scale.x *= -1;
        }
        transform.localScale = scale;

    }

    private void InDialogue()
    {
        dTrigger = gameObject.GetComponent<DialogueTrigger>();
        dTrigger.TriggerDialogue();
    }
   
}
