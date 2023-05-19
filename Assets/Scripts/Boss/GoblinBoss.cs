using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Threading.Tasks;
using UnityEngine;

public class GoblinBoss : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    Rigidbody2D rb;
    public float speed;
    private Transform currentPoint;
    HelperScript helper;
    GoblinHealth goblinHealth;
    PlayerScripts playerS;
    public Transform player;
    public Transform Goblin;
    private Animator anim;
    BoxCollider2D boxCollider;
    private string currentState;
    bool enemyAttack;
    const string SKELETON_PATROL = "Goblin Walk";
    const string SKELETON_ATTACK = "Goblin Attack";
    const string SKELETON_TAKE_HIT = "Goblin Take Hit";
    const string SKELETON_DEATH = "Goblin Death";
    public GameObject playerO;
    MStates state;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        helper = GetComponent<HelperScript>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        state = MStates.Patrol;
        enemyAttack = false;
        goblinHealth = GetComponent<GoblinHealth>();
        playerS = playerO.GetComponent<PlayerScripts>();


    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
        if (enemyAttack == false)
        {
            state = MStates.Patrol;
        }
        playerO = GameObject.Find("Player");
    }

    void DoLogic()
    {
        if (state == MStates.Patrol)
        {
            PatrolEnemy();
        }
        if (state == MStates.Attack)
        {
            EnemyAttack();
        }
        if (state == MStates.TakeHit)
        {
            EnemyTakeHit();
        }
        if (state == MStates.Dead)
        {
            EnemyDead();
        }
    }

    void PatrolEnemy()
    {
        ChangeAnimationState(SKELETON_PATROL);
        speed = 8f;
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
            state = MStates.Attack;
        }
        if (goblinHealth.health <= 0)
        {
            state = MStates.Dead;
        }
    }

    void EnemyAttack()
    {
        ChangeAnimationState(SKELETON_ATTACK);
        speed = 0f;

        if (enemyAttack == false)
        {
            state = MStates.Patrol;
        }
        if (goblinHealth.health <= 0)
        {
            state = MStates.Dead;
        }
        if (goblinHealth.health < goblinHealth.currentHealth)
        {
            state = MStates.TakeHit;
        }
    }

    public async void EnemyTakeHit()
    {
        ChangeAnimationState(SKELETON_TAKE_HIT);
        await Task.Delay(140);
        state = MStates.Attack;
    }

    public void EnemyDead()
    {
        Destroy(this.gameObject);
    }

    void EnemyDamagePlayer()
    {
        playerS.playerHealth -= 25;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            ChangeAnimationState(SKELETON_DEATH);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
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
