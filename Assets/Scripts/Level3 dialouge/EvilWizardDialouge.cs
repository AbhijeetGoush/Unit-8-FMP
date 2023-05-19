using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvilWizardDialouge : MonoBehaviour
{
    public TextMeshProUGUI evilWizardDialouge;
    public int line;
    // Start is called before the first frame update
    void Start()
    {
        evilWizardDialouge = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (line == 1)
        {
            evilWizardDialouge.text = "I can't believe you made it this far";
        }
        if (line == 2)
        {
            evilWizardDialouge.text = "It's a shame that this is where your story ends";
        }
        if (line == 3)
        {
            evilWizardDialouge.text = "Because I will abolish this world";
        }
    }

    
}
