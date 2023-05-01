using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public string text;
    public GameObject scoreUpdaterObj;
    ScoreUpdater sU;
    // Start is called before the first frame update
    void Start()
    {
        sU = scoreUpdaterObj.GetComponent<ScoreUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sU.score++;
            
            Destroy(this.gameObject);
            
        }
    }
}
