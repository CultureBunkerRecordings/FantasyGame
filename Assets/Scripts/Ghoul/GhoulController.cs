using UnityEngine;

public class GhoulController : MonoBehaviour
{

    public ParticleSystem particles;
    private Animator ghoulAnim;
    playerController pController;
    GameManager gManager;
    public LayerMask enemyLayer;
    public float attackRadius;
    public Transform attackPoint;

    public GameObject spellPrefab;
    bool hasPotion;
    bool hasPickedUp;

    Vector3 spellDirection;
    bool hasMagic;
    public float fireSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        pController = GameObject.Find("PlayerController").GetComponent<playerController>();
        ghoulAnim = GetComponent<Animator>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //stomp();
        drinkPotion();
        blueAttack();
        //hasBluePotion();
        walkingAnim();
        JumpingAnim();
        attack();
    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions == 0)
        {
            ghoulAnim.SetTrigger("attack");

            Collider[] enemyHits = Physics.OverlapSphere(attackPoint.position, attackRadius, enemyLayer);

            foreach (var enemy in enemyHits)
            {
                Debug.Log(enemy.name + "Hit");
                enemy.GetComponent<EnemyHealth>().takeDamage();
            }
        }

    }

    void stomp()
    {
        if (Input.GetKey(pController.downKey) && pController.isJumping)
        {
            ghoulAnim.SetBool("stomp", true);
        }
        else
        {
            ghoulAnim.SetBool("stomp", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    void walkingAnim()
    {
        if (pController.isWalkingAcross || pController.isWalkingUp && pController.onGround)
        {
            ghoulAnim.SetBool("walk", true);
        }
        else
        {
            ghoulAnim.SetBool("walk", false);
        }
    }

    void JumpingAnim()
    {
        if (pController.isJumping)
        {
            ghoulAnim.SetBool("jump", true);
        }
        else
        {
            ghoulAnim.SetBool("jump", false);
        }
    }

    void drinkPotion()
    {
        if (pController.isPickingup)
        {
            ghoulAnim.SetTrigger("drinkPotion");
        }

    }


    void blueAttack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p1Potions > 0)
        {
            ghoulAnim.SetTrigger("blueAttack");
            particles.Play();
            pController.p1Potions--;
            gManager.updateP1Potions(pController.p1Potions);

            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (allEnemies != null)
            {
                foreach (var enemy in allEnemies)
                {
                    Destroy(enemy);
                }
            }
        }

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
}
