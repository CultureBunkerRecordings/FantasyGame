using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 5;
    public float jumpForce;

    private float x = 0;
    private float y;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode jumpKey;

    public bool facingRight = true;
    private bool onGround = false;
    private bool touchingGround = false;

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
        if (gameManager.gamePlaying)
        {
            groundCheck();
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
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            touchingGround = true;
        }

        if (collision.gameObject.tag == "Pickups")
        {
            Destroy(collision.gameObject);
            pickups = gameManager.score;
            pickups++;
            gameManager.updateScore(pickups);
        }

    }

    void groundCheck()
    {
        if (rb.velocity.y != 0.0f && !touchingGround)       //ground check stops player from jumping if not touching the ground
        {
            onGround = false;
        }
        else
        {
            onGround = true;
        }
    }

    private void jumping()
    {
        if (Input.GetKeyDown(jumpKey) && onGround == true)            // jump
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            touchingGround = false;
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
   
}
