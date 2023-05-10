using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGemHb : MonoBehaviour
{
    public Transform fireGem;
    public Transform fireGemHb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireGem != null)
        {
            fireGemHb.transform.position = fireGem.position;
        }
    }

    public void FindFireGemPos()
    {
        fireGem = GameObject.FindWithTag("FireGem").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
