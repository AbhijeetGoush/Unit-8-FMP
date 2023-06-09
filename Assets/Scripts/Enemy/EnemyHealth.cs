using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    Animator anim;
    EnemyPatrol enemy;
    
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
            anim.Play("SkeletonTakeHit");

            enemy = GetComponent<EnemyPatrol>();
            enemy.EnemyTakeHit();

        }

        if (health <= 0)
        {
            enemy.EnemyDead();
        }
    }
}
