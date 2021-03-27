using UnityEngine;

public class GhoulController : MonoBehaviour
{

    public Animator ghoulAnim;
    playerController pController;

    GameManager gManager;

    public GameObject spellPrefab;
    public float fireSpeed = 1000;

    Vector2 spellDirection;
    public bool hasMagic = false;

    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void findSpellDirection()
    {
        if (pController.facingRight)
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
        if (Input.GetKey(pController.attackKey) && pController.p1Potions  > 0)
        {
            hasMagic = true;
        }
        else if (Input.GetKeyUp(pController.attackKey) && pController.p1Potions > 0)
        {
            var newSpellPrefab = Instantiate(spellPrefab, transform.position, transform.rotation);
            newSpellPrefab.GetComponent<Rigidbody2D>().AddForce(spellDirection * fireSpeed);
            pController.p1Potions--;
            gManager.updateP1Potions(pController.p1Potions);
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
        if (pController.isWallJumping)
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
        if (pController.isJumping)
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
