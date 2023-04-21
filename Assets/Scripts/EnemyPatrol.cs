using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    Rigidbody2D rb;
    public float speed;
    private Transform currentPoint;
    HelperScript helper;
    EnemyHealth eHealth;
    public Transform player;
    public Transform skeleton;
    private Animator anim;
    BoxCollider2D boxCollider;
    private string currentState;
    bool enemyAttack;
    const string SKELETON_PATROL = "SkeletonWalk";
    const string SKELETON_ATTACK = "SkeletonAttack";
    const string SKELETON_TAKE_HIT = "SkeletonTakeHit";
    const string SKELETON_DEATH = "SkeletonDeath";
    EStates state;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        helper = GetComponent<HelperScript>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        state = EStates.Patrol;
        enemyAttack = false;
        eHealth = GetComponent<EnemyHealth>();
        eHealth.health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
        if (eHealth.health <=0)
        {
            EnemyDead();
        }
    }

    void DoLogic()
    {
        if (state == EStates.Patrol)
        {
            PatrolEnemy();
        }
        if (state == EStates.Attack)
        {
            EnemyAttack();
        }
        if (state == EStates.TakeHit)
        {
            EnemyTakeHit();
        }
        if (state == EStates.Dead)
        {
            EnemyDead();
        }
    }

    void PatrolEnemy()
    {
        ChangeAnimationState(SKELETON_PATROL);
        speed = 2f;
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
            helper.FlipObject(false);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
            helper.FlipObject(true);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        if (enemyAttack == true)
        {
            state = EStates.Attack;
        }
        if (eHealth.health <= 0)
        {
            state = EStates.Dead;
        }
    }

    void EnemyAttack()
    {
        ChangeAnimationState(SKELETON_ATTACK);
        speed = 0f;
        
        if (enemyAttack == false)
        {
            state = EStates.Patrol;
        }
        if (eHealth.health <= 0)
        {
            state = EStates.Dead;
        }
        
    }

    public void EnemyTakeHit()
    {
        ChangeAnimationState(SKELETON_TAKE_HIT);
    }

    public void EnemyDead()
    {
        Destroy(this.gameObject);
    }

    

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyAttack = true;
            ChangeAnimationState(SKELETON_ATTACK);
            speed = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyAttack = false;
        }
    }


}
