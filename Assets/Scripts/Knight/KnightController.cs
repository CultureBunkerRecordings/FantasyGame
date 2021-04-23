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
    public bool hasPotion;
    public bool hasPickedUp;
    public bool kicking;

    public GameObject daggerPrefab;
    public float throwPower = 300;
    // Start is called before the first frame update
    void Start()
    {
        knight = new Characters();
        knight.pController = pController;
        knight.anim = GetComponent<Animator>();
        knight.particles = particles;
        knight.enemyLayer = enemyLayer;
        knight.attackPoint = attackPoint;
        knight.attackRadius = attackRadius;
        knight.hasPotion = hasPotion;
        knight.hasPickedUp = hasPickedUp;
        knight.kicking = kicking;
        knight.throwPower = throwPower;
        knight.daggerPrefab = daggerPrefab;
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
        knight.UpperCut();
        

        knight.facingRight = pController.facingRight;

        if (pController.hasSword)
        {
            knight.updateDaggerAnimationLayerWeight(0);
            knight.updateSwordAnimationLayerWeight(1);
        }

        if (pController.hasDaggers)
        {
            knight.updateSwordAnimationLayerWeight(0);
            knight.updateDaggerAnimationLayerWeight(1);
        }
    }
}
