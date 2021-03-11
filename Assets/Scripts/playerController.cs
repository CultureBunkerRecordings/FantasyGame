using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    GameManager gameManager;
    public float speed = 5;
    public float jumpForce;

    private float x;
    private float y;

    private bool facingRight = true;
    private bool onGround = false;
    private bool touchingGround = false;

    private int pickups = 0;

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
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            touchingGround = true;
        }

        if (collision.gameObject.tag == "Pickups")
        {
            Destroy(collision.gameObject);
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

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)            // jump
        {
            rb.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            touchingGround = false;
        }
    }

    private void movement()
    {
        x = Input.GetAxis("Horizontal");                            //move left and right
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
