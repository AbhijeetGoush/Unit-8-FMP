using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodWizardScript : MonoBehaviour
{
    PlayerScripts player;
    public GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<PlayerScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.state = States.Talking;
        }
    }
}
