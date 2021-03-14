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
        if (Input.GetKey(KeyCode.Z) && pController.pickups > 0)
        {
            hasMagic = true;
        }
        else if (Input.GetKeyUp(KeyCode.Z) && pController.pickups > 0)
        {
            var newSpellPrefab = Instantiate(spellPrefab, transform.position, transform.rotation);
            newSpellPrefab.GetComponent<Rigidbody2D>().AddForce(spellDirection * fireSpeed);
            pController.pickups--;
            gManager.updateScore(pController.pickups);
            hasMagic = false;
        }
        else
        {
            hasMagic = false;
        }
        ghoulAnim.SetBool("attack", hasMagic);
    }

    // Update is called once per frame
    void Update()
    {
        findSpellDirection();
        fireSpell();
    }
}
