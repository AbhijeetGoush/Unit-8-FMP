using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;
    Animator anim;
    LoadScene scene;
    GoblinBoss goblinBoss;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
        scene = GetComponent<LoadScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < currentHealth)
        {
            currentHealth = health;
            anim.Play("MushroomTakeHit");

            goblinBoss = GetComponent<GoblinBoss>();
            goblinBoss.EnemyTakeHit();

        }

        if (health <= 0)
        {
            goblinBoss.EnemyDead();
            scene.LoadScene3();
        }
    }
}

