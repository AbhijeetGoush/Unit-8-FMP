using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPointScript : MonoBehaviour
{
    public Transform attackPoint;
    public Transform attackPointFront;
    public Transform attackPointBehind;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            attackPoint.transform.position = attackPointBehind.position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            attackPoint.transform.position = attackPointFront.position;
        }

    }
}
