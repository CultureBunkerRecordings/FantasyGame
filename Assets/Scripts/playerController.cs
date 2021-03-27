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
    public bool isPickingup = false;

    public float speed = 5;
    public float jumpForce;

    private float x = 0;
    private float y;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public KeyCode attackKey;

    public bool isJumping = false;
    public bool isWalking = false;
    public bool facingRight = true; 
    public bool onGround = false;
    public bool onWall = false;
    public bool onBehindWall = false;
    public bool isWallJumping = false;
   
    public Transform GroundCheck;
    public Transform FrontCheck;
    public Transform BackCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    public int p1Potions;
    public int p2Potions;

    public int health1;
    public int health2;
    private Rigidbody2D rb;

    public GameObject[] p1Character;
    public GameObject[] p2Character;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.p1Health = health1;
        gameManager.p2Health = health2;
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
            wallJumpCheck();

            jumpingCheck();
            jump();
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
            isPickingup = true;
            Destroy(collision.gameObject);
            if (gameObject.name == "PlayerController")
            {
                p1Potions = gameManager.p1Potions;
                p1Potions++;
                gameManager.updateP1Potions(p1Potions);
            }
            else if (gameObject.name == "Player2Controller")
            {
                p2Potions = gameManager.p2Potions;
                p2Potions++;
                gameManager.updateP2Potions(p2Potions);
            }
        }
        else
        {
            isPickingup = false;
        }

        if(collision.gameObject.tag == "Enemy")
        {
            if(health1 >= 0 && gameObject.name == "PlayerController") 
            {
                health1--;
                gameManager.updateP1Health(health1);

            }

            if (health2 >= 0 && gameObject.name == "Player2Controller")
            {
                health2--;
                gameManager.updateP2Health(health2);
            }

        }

    }

    void wallCheck()
    {
        onWall = Physics2D.OverlapCircle(FrontCheck.position, checkRadius, WhatIsGround);
        onBehindWall = Physics2D.OverlapCircle(BackCheck.position, checkRadius, WhatIsGround);
    }

    void wallJumpCheck()
    {
        if (onBehindWall && !onGround && Input.GetKeyDown(jumpKey))
        {
            isWallJumping = true;
        }
        else
        {
            isWallJumping = false;
        }
    }

    void groundCheck()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, WhatIsGround);
    }

    private void jump()
    {
        if (Input.GetKeyDown(jumpKey) && (onGround == true || onBehindWall == true))            // jump
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }  
    }

    public void jumpingCheck()
    {
        if(!onGround && !isWallJumping)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }

    public void P1FaunSelect()
    {
        foreach(var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[0].SetActive(true);
        gameManager.updatePlayer1Character(0);
    }

    public void P1GhoulSelect()
    {
        foreach (var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[1].SetActive(true);
        gameManager.updatePlayer1Character(1);
    }

    public void P1SkeletonSelect()
    {
        foreach (var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[2].SetActive(true);
        gameManager.updatePlayer1Character(2);
    }

    public void P1WerewolfSelect()
    {
        foreach (var c in p1Character)
        {
            c.SetActive(false);
        }

        p1Character[3].SetActive(true);
        gameManager.updatePlayer1Character(3);
    }

    public void P2FaunSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[0].SetActive(true);
        gameManager.updatePlayer2Character(0);
    }

    public void P2GhoulSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[1].SetActive(true);
        gameManager.updatePlayer2Character(1);
    }

    public void P2SkeletonSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[2].SetActive(true);
        gameManager.updatePlayer2Character(2);
    }

    public void P2WerewolfSelect()
    {
        foreach (var c in p2Character)
        {
            c.SetActive(false);
        }

        p2Character[3].SetActive(true);
        gameManager.updatePlayer2Character(3);
    }

    private void movement()
    {
        if (Input.GetKey(rightKey))
        {
            x = 1;
            isWalking = true;
        }
        else if(Input.GetKey(leftKey))
        {
            x = -1;
            isWalking = true;
        }
        else
        {
            x = 0;
            isWalking = false;
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
