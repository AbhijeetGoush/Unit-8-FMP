using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    Animator anim;
    FlyingEye flyingEye;

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

            flyingEye = GetComponent<FlyingEye>();
            flyingEye.EnemyTakeHit();

        }

        if (health <= 0)
        {
            flyingEye.EnemyDead();
        }
    }
}
