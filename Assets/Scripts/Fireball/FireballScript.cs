using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    FireballPos fireballPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
        fireballPos = GetComponent<FireballPos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireballPos.facingLeft == true)
        {

        }

        if (fireballPos.facingRight == true)
        {

        }
    }
}
