using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialouge : MonoBehaviour
{
    public Transform playerAbove;
    public Transform playerDialouge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAbove != null)
        {
            playerDialouge.transform.position = playerAbove.position;
        }
    }
}
