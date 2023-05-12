using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPos : MonoBehaviour
{
    public Transform fireballSpawner;
    public Transform fireballSpawnerFront;
    public Transform fireballSpawnerBehind;
    public bool facingLeft;
    public bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            fireballSpawner.transform.position = fireballSpawnerBehind.position;
            facingLeft = true;
            facingRight = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            fireballSpawner.transform.position = fireballSpawnerFront.position;
            facingRight = true;
            facingLeft = false;
        }
        
    }

    
}
