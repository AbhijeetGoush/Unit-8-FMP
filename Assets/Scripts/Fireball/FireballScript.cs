using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    FireballPos fireballPos;
    public float speed = 10f;
    public bool facingLeft;
    public bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (facingLeft == true)
        {
            transform.localScale = new Vector3(-3, -3, 0);
            transform.position = new Vector3(transform.position.x + (-speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
        if (facingRight == true)
        {
            transform.localScale = new Vector3(-3, 3, 0);
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z);
        }
    }
    

}
