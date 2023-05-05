using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : MonoBehaviour
{
    public GameObject player;
    public float speed = 2;
    public float distanceBetween;
    private float distance;
    PlayerScripts playerS;
    public GameObject playerO;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerS = playerO.GetComponent<PlayerScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            if (distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            }
            if (distance > distanceBetween)
            {
                anim.Play("SkeletonBossIdle");
            }
        }

        if (playerS.playerHealth <= 0)
        {
            anim.Play("SkeletonBossIdle");
        }
    }

    void BossDamagePlayer()
    {
        playerS.playerHealth -= 40;
    }

    public void BossTakeHit()
    {

    }

    public void BossDead()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speed = 0;
            
            anim.SetBool("Attack", true);
        }

        if (collision.tag == "Barrier")
        {
            speed = 0;
            anim.Play("SkeletonBossIdle");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speed = 2;
            anim.Play("SkeletonBossWalk");
        }

        if (collision.tag == "Barrier")
        {
            speed = 2;
            anim.Play("SkeletonBossWalk");
        }

    }


}
