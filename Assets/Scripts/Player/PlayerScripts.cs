using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    public States state;
    Rigidbody2D rb;
    bool grounded;
    Animator anim;
    HelperScript helper;
    EnemyHealth eHealth;
    BossHealth bHealth;
    FireballScript fireball;
    CameraScript cam;
    public GameObject fireballObj;
    public GameObject rightBarrier;
    private string currentState;
    const string PLAYER_IDLE = "PlayerIdle";
    const string PLAYER_RUN = "PlayerRun";
    const string PLAYER_JUMP = "PlayerJump";
    const string PLAYER_ATTACK = "PlayerAttack";
    const string PLAYER_DEATH = "PlayerDeath";
    public int playerHealth;
    public bool canUseFireball;
    public GameObject attackPoint;
    public GameObject attackpoint1;
    public GameObject fireGemHb;
    public GameObject fireballPrefab;
    public GameObject cameraObj;
    public Transform fireballSpawner;
    public PlayerScripts player;
    public float radius;
    public int fireballCount;
    public LayerMask enemies;
    public LayerMask mushrooms;
    public LayerMask bosses;
    public LayerMask flyingEyes;
    public LayerMask goblins;
    public LayerMask wizards;

    
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        anim = GetComponent<Animator>();
        helper = GetComponent<HelperScript>();
        playerHealth = 100;
        eHealth = GetComponent<EnemyHealth>();
        bHealth = GetComponent<BossHealth>();
        fireball = fireballObj.GetComponent<FireballScript>();
        cam = cameraObj.GetComponent<CameraScript>();
        canUseFireball = false;
        fireballCount = 2;

        
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();
        Vector2 vel = rb.velocity;
        rb.velocity = vel;

        if (playerHealth <= 0)
        {
            state = States.Dead;
        }
        if (Input.GetKeyDown(KeyCode.F) && (canUseFireball == true))
        {
            Fireball();
            fireballCount--;
        }
        if (fireballCount <= -1)
        {
            state = States.Dead;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            fireball.facingLeft = true;
            fireball.facingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            fireball.facingRight = true;
            fireball.facingLeft = false;
        }

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
            
            enemyGameObject.GetComponent<EnemyHealth>().health -= 10;
        }
        
    }

    void PlayerAttackingBoss()
    {
        Collider2D[] boss = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, bosses);
        foreach (Collider2D bossGameObject in boss)
        {
            Debug.Log("hit boss");
            bossGameObject.GetComponent<BossHealth>().health -= 10;
        }
    }

    void PlayerAttackingFlyingEye()
    {
        Collider2D[] flyingEye = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, flyingEyes);
        foreach (Collider2D flyingEyeGameObject in flyingEye)
        {
            flyingEyeGameObject.GetComponent<FlyingEyeHealth>().health -= 10;
        }
    }

    void PlayerAttackingMushroom()
    {
        Collider2D[] mushroom = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, mushrooms);
        foreach (Collider2D mushroomGameObject in mushroom)
        {

            mushroomGameObject.GetComponent<MushroomHealth>().health -= 10;
        }
    }

    void PlayerAttackingGoblin()
    {
        Collider2D[] goblin = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, goblins);
        foreach (Collider2D goblinGameObject in goblin)
        {

            goblinGameObject.GetComponent<GoblinHealth>().health -= 10;
        }
    }

    void PlayerAttackingWizard()
    {
        Collider2D[] wizard = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, wizards);
        foreach (Collider2D wizardGameObject in wizard)
        {

            wizardGameObject.GetComponent<EvilWizardHealth>().health -= 10;
        }
    }


    public void PlayerTakeDamage()
    {
        playerHealth -= 25;

        
    }

    void PlayerTakeDamageWizard()
    {
        playerHealth -= 50;
    }
    public async void PlayerDead()
    {
        if (playerHealth <= 0)
        {
            ChangeAnimationState(PLAYER_DEATH);
            await Task.Delay(1350);
            if (player != null)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }

        if (fireballCount <= -1)
        {
            ChangeAnimationState(PLAYER_DEATH);
            await Task.Delay(1350);
            if (player != null)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("GameOver");
            }
        }
        
    }

    public void PlayerTalking()
    {
        Vector2 vel = rb.velocity;
        rb.velocity = vel;

        vel.x = 0;
        

    }
    
    void Fireball()
    {
        if (fireballCount > 0)
        {
            Instantiate(fireballPrefab, fireballSpawner.transform.position, Quaternion.identity);
        }
        
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
        if (collision.gameObject.tag == "FloorBarrier")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.tag == "Boss Fire")
        {
            PlayerTakeDamageWizard();
            Destroy(collision.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireGemHb")
        {
            canUseFireball = true;
            Destroy(rightBarrier);
            cam.FindPlayer();
            Destroy(fireGemHb);
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
