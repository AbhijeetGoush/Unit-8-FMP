using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public Transform player;
    public Transform background;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        background.position = new Vector3(player.position.x + 7.5f, player.position.y + 1.7f, transform.position.z) ;
    }
}
