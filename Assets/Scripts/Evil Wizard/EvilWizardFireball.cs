using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizardFireball : MonoBehaviour
{
    public GameObject playerObj;
    PlayerScripts playerScripts;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 0, 90);
        playerScripts = playerObj.GetComponent<PlayerScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = new Vector3(-3, -3, 0);
        transform.position = new Vector3(transform.position.x + (-speed * Time.deltaTime), transform.position.y, transform.position.z);
        
    }

    
}
