using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilWizardDialogue : MonoBehaviour
{
    public TextMeshProUGUI wizard;
    public TextMeshProUGUI player;
    public GameObject wizardObj;
    EvilWizardHealth wizardHealth;
    public int line;
    // Start is called before the first frame update
    void Start()
    {
        wizard = wizard.GetComponent<TextMeshProUGUI>();
        wizardHealth = wizardObj.GetComponent<EvilWizardHealth>();
        line = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (line == 1)
        {
            wizard.text = "HOW IS THIS POSSIBLE!!!";
        }
        if (line == 2)
        {
            player.text = "You threw the fireballs in the same pattern so it was easy to jump over";
            wizard.text = "";
        }
        if (line == 3)
        {
            player.text = "";
            wizard.text = "Oh...";
        }
        if (line == 4)
        {
            player.text = "Get good";
            wizard.text = "";
        }
        if (line == 5)
        {
            player.text = "";
            wizard.text = ":(";
        }
        if (line == 6)
        {
            SceneManager.LoadScene("Win");
        }
    }

    public void Count()
    {
        if (wizardHealth.health <= 0)
        {
            line++;
        }
    }
}
