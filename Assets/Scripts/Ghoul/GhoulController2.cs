using UnityEngine;

public class GhoulController2 : MonoBehaviour
{

    public Animator ghoulAnim;
    playerController p2Controller;

    GameManager gManager;

    public GameObject spellPrefab;
    public float fireSpeed = 1000;

    Vector2 spellDirection;
    public bool hasMagic = false;

    // Start is called before the first frame update
    void Start()
    {
        p2Controller = GameObject.Find("Player2Controller").GetComponent<playerController>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void findSpellDirection()
    {
        if (p2Controller.facingRight)
        {
            spellDirection = Vector2.right;
        }
        else
        {
            spellDirection = -Vector2.right;
        }
    } 

    private void fireSpell()
    {
        if (Input.GetKey(KeyCode.Z) && p2Controller.pickups  > 0)
        {
            hasMagic = true;
        }
        else if (Input.GetKeyUp(KeyCode.Z) && p2Controller.pickups > 0)
        {
            var newSpellPrefab = Instantiate(spellPrefab, transform.position, transform.rotation);
            newSpellPrefab.GetComponent<Rigidbody2D>().AddForce(spellDirection * fireSpeed);
            p2Controller.pickups--;
            gManager.updateScore(p2Controller.pickups);
            hasMagic = false;
        }
        else
        {
            hasMagic = false;
        }
        ghoulAnim.SetBool("attack", hasMagic);
    }

    void wallJump()
    {
        if (p2Controller.isWallJumping)
        {
            ghoulAnim.SetBool("wallJumping", true);
        }
        else
        {
            ghoulAnim.SetBool("wallJumping", false);
        }
    }

    void jumpAnim()
    {
        if (p2Controller.isJumping)
        {
            ghoulAnim.SetBool("isJumping", true);
        }
        else
        {
            ghoulAnim.SetBool("isJumping", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        findSpellDirection();
        fireSpell();
        wallJump();
        jumpAnim();
    }
}
