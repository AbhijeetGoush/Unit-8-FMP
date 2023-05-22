using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizardHealth : MonoBehaviour
{
    EvilWizardScript evilWizard;
    public int health;
    BoxCollider2D WizardCol;
    Rigidbody2D wizardRig;
    // Start is called before the first frame update
    void Start()
    {
        evilWizard = GetComponent<EvilWizardScript>();
        WizardCol = GetComponent<BoxCollider2D>();
        wizardRig = GetComponent<Rigidbody2D>();
        health = 200;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            evilWizard.attack = false;
;           evilWizard.WizardDeath();
            Destroy(WizardCol);
            Destroy(wizardRig);
        }
    }

   
}
