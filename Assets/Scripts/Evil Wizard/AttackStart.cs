using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStart : MonoBehaviour
{
    public GameObject evilWizard;
    EvilWizardScript evilWizardScript;
    // Start is called before the first frame update
    void Start()
    {
        evilWizardScript = evilWizard.GetComponent<EvilWizardScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            evilWizardScript.attack = true;
        }
    }

}
