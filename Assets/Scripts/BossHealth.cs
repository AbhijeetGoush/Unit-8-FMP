using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    Animator anim;
    BossChase boss;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currentHealth)
        {
            currentHealth = health;
            anim.Play("SkeletonBossTakeHit");

            boss = GetComponent<BossChase>();
            boss.BossTakeHit();

        }

        if (health <= 0)
        {
            boss.BossDead();
        }
    }
}
