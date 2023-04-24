using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    States state;
    Rigidbody2D rb;
    bool grounded;
    Animator anim;
    HelperScript helper;
    private string currentState;
    const string PLAYER_IDLE = "PlayerIdle";
    const string PLAYER_RUN = "PlayerRun";
    const string PLAYER_JUMP = "PlayerJump";
    const string PLAYER_ATTACK = "PlayerAttack";
    public int playerhealth;
    public GameObject attackPoint;
    public GameObject attackpoint1;
    public float radius;
    public LayerMask enemies;
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        anim = GetComponent<Animator>();
        helper = GetComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
        Vector2 vel = rb.velocity;
        rb.velocity = vel;
    }

    void FixedUpdate()
    {
        grounded = false;
    }

    void DoLogic()
    {
        if (state == States.Idle)
        {
            PlayerIdle();
        }

        if (state == States.Jump)
        {
            PlayerJump();
        }

        if (state == States.Walk)
        {
            PlayerWalk();
        }

        if (state == States.Dead)
        {
            PlayerDead();
        }
        if (state == States.Attack)
        {
            PlayerAttack();
        }
    }

    void PlayerIdle()
    {
        Vector2 vel = rb.velocity;
        vel.x = 0;
        rb.velocity = vel;

        if (vel.x == 0)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }

        if (Input.GetKey(KeyCode.D))
        {
            state = States.Walk;
        }
        if (Input.GetKey(KeyCode.A))
        {
            state = States.Walk;
        }
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            state = States.Jump;
            rb.velocity = new Vector2(0, 6);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            state = States.Attack;
        }
    }

    void PlayerJump()
    {
        Vector2 vel = rb.velocity;

        if (grounded == false)
        {
            ChangeAnimationState(PLAYER_JUMP);
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 4;
            helper.FlipObject(false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -4;
            helper.FlipObject(true);
        }
        // player is jumping, check for hitting the ground
        if (grounded == true)
        {
            //player has landed on floor
            state = States.Idle;
        }
        rb.velocity = vel;
    }

    void PlayerWalk()
    {
        Vector2 vel = rb.velocity;

        if (Input.GetKey(KeyCode.D))
        {
            vel.x = 4;
            helper.FlipObject(false);
            ChangeAnimationState(PLAYER_RUN);
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel.x = -4;
            helper.FlipObject(true);
            ChangeAnimationState(PLAYER_RUN);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            state = States.Idle;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            state = States.Idle;
        }
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            state = States.Jump;
            rb.velocity = new Vector2(0, 6);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            vel.x = 0;
            state = States.Attack;
        }
        rb.velocity = vel;
    }

    void PlayerAttack()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ChangeAnimationState(PLAYER_ATTACK);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            state = States.Idle;   
        }
    }
    void PlayerAttacking()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);
        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("hit enemy");
            enemyGameObject.GetComponent<EnemyHealth>().health -= 10;
        }
    }

    void PlayerDead()
    {

    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            grounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            state = States.Jump;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }


}