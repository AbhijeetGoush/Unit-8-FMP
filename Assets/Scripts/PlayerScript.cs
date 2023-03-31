using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    bool touchingplatform;
    //bool Jumping;
    HelperScript helper;
    Animator anim;
    private string currentState;
    const string PLAYER_IDLE = "PlayerIdle";
    const string PLAYER_RUN = "PlayerRun";
    const string PLAYER_JUMP = "PlayerJump";
    const string PLAYER_ATTACK = "PlayerAttack";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        helper = GetComponent<HelperScript>();
        touchingplatform = false;
        anim = GetComponent<Animator>();
        //Jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;
        
        if (Input.GetKey(KeyCode.D))
        {
            ChangeAnimationState(PLAYER_RUN);
            vel.x = 4;
        }
        if (Input.GetKey(KeyCode.A))
        {
            ChangeAnimationState(PLAYER_RUN);
            vel.x = -4;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            vel.x = 0;
            ChangeAnimationState(PLAYER_IDLE);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            vel.x = 0;
            ChangeAnimationState(PLAYER_IDLE);
        }
        if (Input.GetKey(KeyCode.W) && (touchingplatform == true))
        {
            vel.y = 6;
        }
        if (Input.GetKey(KeyCode.Space) && (touchingplatform == true))
        {
            vel.y = 6;
        }
        if (Input.GetKey(KeyCode.A))
        {
            helper.FlipObject(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            helper.FlipObject(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChangeAnimationState(PLAYER_ATTACK);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ChangeAnimationState (PLAYER_IDLE);
        }
        
        rb.velocity = vel;
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
            touchingplatform = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            touchingplatform = false;
        }
    }

}
