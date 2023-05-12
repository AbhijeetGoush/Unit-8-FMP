using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodWizardScript : MonoBehaviour
{
    PlayerScripts player;
    public GameObject playerObj;
    GoodWizardScript goodWizard;
    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<PlayerScripts>();
        goodWizard = gameObject.GetComponent<GoodWizardScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
