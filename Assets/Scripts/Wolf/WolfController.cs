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

    bool leftOrRightTarget;
    public Transform leftTarget;
    public Transform rightTarget;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveAndWait(leftTarget.position, rightTarget.position));
    }

    // Update is called once per frame
    void Update()
    {

        howlCheck();
    }

    private void LateUpdate()
    {
        flip();
    }

    IEnumerator moveAndWait(Vector2 leftTarget, Vector2 rightTarget)
    {
        while (Vector2.Distance(transform.position, leftTarget) > 0.2 && !facingRight)
        {
            isMoving = true;
            transform.position += -Vector3.right * speed * Time.deltaTime;
            yield return null;
        }
        while (Vector2.Distance(transform.position, rightTarget) > 0.2 && facingRight)
        {
            isMoving = true;
            transform.position += Vector3.right * speed * Time.deltaTime;
            yield return null;
        }

        if(Vector2.Distance(transform.position, leftTarget) < 0.2 || Vector2.Distance(transform.position, rightTarget) < 0.2)
        {
            isMoving = false;
        }

        yield return new WaitForSeconds(2);

        if (turn)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }

        yield return moveAndWait(leftTarget, rightTarget);   
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
