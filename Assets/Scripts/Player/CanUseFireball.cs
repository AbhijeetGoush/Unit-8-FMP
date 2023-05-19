using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanUseFireball : MonoBehaviour
{
    public GameObject player;
    PlayerScripts playerS;
    // Start is called before the first frame update
    void Start()
    {
        playerS = player.GetComponent<PlayerScripts>();
        
    }

    // Update is called once per frame
    void Update()
    {
        playerS.canUseFireball = true;
    }
}
