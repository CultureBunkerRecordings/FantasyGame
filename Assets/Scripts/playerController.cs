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
    public bool isPickingUpRed = false;
    public bool isPickingUpBlue = false;
    public bool hasBlue = false;
    public bool isPickingUpGreen = false;
    public bool isPickingUpPurple = false;

    public bool hasDaggers = false;
    public bool hasSword = false;

    public float speed = 5;
    public float jumpForce;

    private float x = 0;
    private float z;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;
    public KeyCode attackKey;
    public KeyCode upKey;
    public KeyCode downKey;

    public bool isJumping = false;
    public bool isWalkingAcross = false;
    public bool isWalkingUp = false;
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
    int maxHealth = 12;
    private Rigidbody rb;

    public bool kicking = false;
    public bool uppercut = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

            pause();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pickups")
        {
            Debug.Log(collision.gameObject.name);
            if (gameObject.name == "PlayerController")
            {
                if (collision.gameObject.name == "RedPotion(Clone)")
                {
                    if(health1 < maxHealth)
                    {
                        health1 = maxHealth;
                        gameManager.updateP1Health(health1);
                    }
                    isPickingUpRed = true;
                }
                else if (collision.gameObject.name == "BluePotion(Clone)")
                {
                    isPickingUpBlue = true;
                    hasBlue = true;
                }
                else if (collision.gameObject.name == "GreenPotion(Clone)")
                {
                    isPickingUpGreen = true;
                }
                else if (collision.gameObject.name == "PurplePotion(Clone")
                {
                    isPickingUpPurple = true;
                }
                else
                {
                    isPickingUpRed = false;
                    isPickingUpBlue = false;
                    isPickingUpGreen = false;
                    isPickingUpPurple = false;
                }
                Destroy(collision.gameObject);
                p1Potions = gameManager.p1Potions;
                p1Potions++;
                gameManager.updateP1Potions(p1Potions);
            }
            else if (gameObject.name == "Player2Controller")
            {
                if (collision.gameObject.name == "RedPotion(Clone)")
                {
                    isPickingUpRed = true;
                }
                else if (collision.gameObject.name == "BluePotion(Clone)")
                {
                    isPickingUpBlue = true;
                    hasBlue = true;
                }
                else if (collision.gameObject.name == "GreenPotion(Clone)")
                {
                    isPickingUpGreen = true;
                }
                else if (collision.gameObject.name == "PurplePotion(Clone)")
                {
                    isPickingUpPurple = true;
                }
                else
                {
                    isPickingUpRed = false;
                    isPickingUpBlue = false;
                    isPickingUpGreen = false;
                    isPickingUpPurple = false;
                }
                Destroy(collision.gameObject);
                p2Potions = gameManager.p2Potions;
                p2Potions++;
                gameManager.updateP2Potions(p2Potions);
            }
        }

        if(collision.gameObject.tag == "Weapons")
        {
           if (gameObject.name == "PlayerController")
            {
                if(collision.gameObject.name == "Daggers(Clone)")
                {
                    hasDaggers = true;
                    GameManager.SingletonInstance.updatePlayer1Weapon(0);
                }
                else if (collision.gameObject.name == "Sword(Clone)")
                {
                    hasSword = true;
                    GameManager.SingletonInstance.updatePlayer1Weapon(1);
                }
                else
                {
                    hasDaggers = false;
                    hasSword = false;
                }
                Destroy(collision.gameObject);
            }
            else if (gameObject.name == "Player2Controller")
            {
                if (collision.gameObject.name == "Daggers(Clone)")
                {
                    hasDaggers = true;
                    GameManager.SingletonInstance.updatePlayer2Weapon(0);
                }
                else if (collision.gameObject.name == "Sword(Clone)")
                {
                    hasSword = true;
                    GameManager.SingletonInstance.updatePlayer2Weapon(1);
                }
                else
                {
                    hasDaggers = false;
                    hasSword = false;
                }
                Destroy(collision.gameObject);
                GameManager.SingletonInstance.hasDagger = hasDaggers;
                GameManager.SingletonInstance.hasSword = hasSword;
            }


        }

    }


    void pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.pauseGame();
        }
    }

    void wallCheck()
    {
        onWall = Physics.CheckSphere(FrontCheck.position, checkRadius, WhatIsGround);
        onBehindWall = Physics.CheckSphere(BackCheck.position, checkRadius, WhatIsGround);

       
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
        onGround = Physics.CheckSphere(GroundCheck.position, checkRadius, WhatIsGround);
    }

    private void jump()
    {
        if (Input.GetKeyDown(jumpKey) && (onGround == true || onBehindWall == true))            // jump
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

    private void movement()
    {
        if (Input.GetKey(rightKey))
        {
            x = 1;
            isWalkingAcross = true;
        }
        else if(Input.GetKey(leftKey))
        {
            x = -1;
            isWalkingAcross = true;
        }
        else
        {
            x = 0;
            isWalkingAcross = false;
        }


        if (Input.GetKey(upKey) && !uppercut)
        {
            z = 1;
            isWalkingUp = true;
        }
        else if (Input.GetKey(downKey) && !kicking)
        {
            z = -1;
            isWalkingUp = true;
        }
        else
        {
            z = 0;
            isWalkingUp = false;
        }


        //move left and right
        rb.velocity = new Vector3(x * speed, rb.velocity.y, z * speed);
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
