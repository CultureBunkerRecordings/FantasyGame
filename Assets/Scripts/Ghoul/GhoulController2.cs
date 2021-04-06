using UnityEngine;

public class GhoulController2 : MonoBehaviour
{
    public ParticleSystem particles;
    private Animator ghoulAnim2;
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
        pController = GameObject.Find("Player2Controller").GetComponent<playerController>();
        ghoulAnim2 = GetComponent<Animator>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //stomp();
        drinkPotion();
        blueAttack();
        walkingAnim();
        JumpingAnim();
        attack();
    }

    void attack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p2Potions == 0)
        {
            ghoulAnim2.SetTrigger("attack");

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
            ghoulAnim2.SetBool("stomp", true);
        }
        else
        {
            ghoulAnim2.SetBool("stomp", false);
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
            ghoulAnim2.SetBool("walk", true);
        }
        else
        {
            ghoulAnim2.SetBool("walk", false);
        }
    }

    void JumpingAnim()
    {
        if (pController.isJumping)
        {
            ghoulAnim2.SetBool("jump", true);
        }
        else
        {
            ghoulAnim2.SetBool("jump", false);
        }
    }

    void drinkPotion()
    {
        if (pController.isPickingUpRed)
        {
            ghoulAnim2.SetTrigger("drinkPotion");
        }

    }


    void blueAttack()
    {
        if (Input.GetKeyDown(pController.attackKey) && pController.p2Potions > 0)
        {
            ghoulAnim2.SetTrigger("blueAttack");
            particles.Play();
            pController.p2Potions--;
            gManager.updateP1Potions(pController.p2Potions);

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
