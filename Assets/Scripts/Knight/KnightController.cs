using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{

    public Characters knight;

    public Animator knightAnim;
    public ParticleSystem particles;
    public playerController pController;
    public LayerMask enemyLayer;
    public float attackRadius;
    public Transform attackPoint;
    public GameObject spellPrefab;
    public bool hasPotion;
    public bool hasPickedUp;
    public bool kicking;
    // Start is called before the first frame update
    void Start()
    {
        knight.pController = GameObject.Find("PlayerController").GetComponent<playerController>();
        knight.anim = GetComponent<Animator>();
        knight.particles = particles;
        knight.enemyLayer = enemyLayer;
        knight.attackPoint = attackPoint;
        knight.attackRadius = attackRadius;
        knight.hasPotion = hasPotion;
        knight.hasPickedUp = hasPickedUp;
        knight.kicking = kicking;
    }

    // Update is called once per frame
    void Update()
    {
        knight.drinkPotions();
        knight.blueAttack();
        knight.kick();
        knight.walkingAnim();
        knight.JumpingAnim();
        knight.attack();
    }
}
