using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    public Transform player;
    private string currentState;
    private float dist;
    public float howClose;
    public GameObject flyingEye;
    PlayerScripts playerS;
    FlyingEyeHealth flyingEyeHealth;
    Animator anim;
    BoxCollider2D boxCollider;
    const string FLYING_EYE_IDLE = "FlyingAnim";
    const string FLYING_EYE_ATTACK = "FlyingEyeAttack";
    const string FLYING_EYE_HIT = "FlyingEyeTakeHit";
    const string FLYING_EYE_DEATH = "FlyingEyeDeath";
    // Start is called before the first frame update
    void Start()
    {
        playerS = player.GetComponent<PlayerScripts>();
        anim = GetComponent<Animator>();
        ChangeAnimationState(FLYING_EYE_IDLE);
        flyingEyeHealth = GetComponent<FlyingEyeHealth>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            dist = Vector3.Distance(player.position, transform.position);

            if (dist <= 2.1 && (flyingEyeHealth.health > 0))
            {
                ChangeAnimationState(FLYING_EYE_ATTACK);
            }
            if (dist > 2.1 && (flyingEyeHealth.health > 0))
            {
                ChangeAnimationState(FLYING_EYE_IDLE);
            }
        }
    }
    void AttackPlayer()
    {
        playerS.PlayerTakeDamage();
    }
    public void EnemyTakeHit()
    {
        ChangeAnimationState(FLYING_EYE_HIT);
    }
    public void EnemyDead()
    {
        ChangeAnimationState(FLYING_EYE_DEATH);
        Destroy(boxCollider);
    }
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            print("hit");
            flyingEyeHealth.health = 0;
            Destroy(collision.gameObject);
        }
    }
}
