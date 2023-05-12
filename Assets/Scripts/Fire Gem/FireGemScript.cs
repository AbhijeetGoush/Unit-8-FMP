using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGemScript : MonoBehaviour
{
    PlayerScripts player;
    public GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<PlayerScripts>();
        playerObj = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        
    }

}
