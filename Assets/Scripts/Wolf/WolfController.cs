using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public bool turn = false;
    public float speed = 2f;
    private bool facingRight = false;
    public bool isMoving = false;
    public Transform howlPoint;
    public LayerMask playersLayer;
    public float howlRange;
    public bool hasSeenPlayer;

    public bool timeReached = false;
    float timer;
    float waitTime = 20;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        howlCheck();
        movement();
    }

    private void LateUpdate()
    {
        flip();
    }

    

    void movement()
    {
        if (turn)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            facingRight = true;
        }
        else
        {
            transform.position += -Vector3.right * speed * Time.deltaTime;
            facingRight = false;
        }   
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

    void howlCheck()
    {
        hasSeenPlayer = Physics2D.OverlapCircle(howlPoint.position, howlRange, playersLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "TurnPointLeft")
            {
                turn = true;
            }
            else if (other.gameObject.tag == "TurnPointRight")
            {
                turn = false;
            }
    }


}
