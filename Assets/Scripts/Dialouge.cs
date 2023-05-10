using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI goodWizard;
    public TextMeshProUGUI player;
    public GameObject cameraObj;
    public GameObject fireGemPrefab;
    public GameObject fireGemSpawn;
    FireGemHb fireGemHb;
    public GameObject fireGemHbObj;
    int gem;
    CameraScript cam;
    public int line;

    // Start is called before the first frame update
    void Start()
    {
        line = 0;
        print(line);
        goodWizard = goodWizard.GetComponent<TextMeshProUGUI>();
        player = player.GetComponent<TextMeshProUGUI>();
        cam = cameraObj.GetComponent<CameraScript>();
        gem = 1;
        fireGemHb = fireGemHbObj.GetComponent<FireGemHb>();
    }

    // Update is called once per frame
    void Update()
    {
        if (line == 1)
        {
            goodWizard.text = "Hello brave knight";
            
        }
        if (line == 2)
        {
            goodWizard.text = "";
            player.text = "Don't 'brave knight' me";
        }
        if (line == 3)
        {
            player.text = "Do you have any idea what I have been through?";
        }
        if (line == 4)
        {
            player.text = "";
            goodWizard.text = "No.";
        }
        if (line == 5)
        {
            goodWizard.text = "Theres no time, I must explain";
        }
        if (line == 6)
        {
            goodWizard.text = "";
            player.text = "Well hurry up then";
        }
        if (line == 7)
        {
            player.text = "";
            goodWizard.text = "Ok";
        }
        if (line == 8)
        {
            player.text = "";
            goodWizard.text = "THE EVIL WIZARD IS TRYING TO DESTROY OUR WORLD!!";
        }
        if (line == 9)
        {
            player.text = "WHAT!!!";
            goodWizard.text = "";
        }
        if (line == 10)
        {
            player.text = "Well, what do you want me to do?";
        }
        if (line == 11)
        {
            goodWizard.text = "Stop him duhhh";
            player.text = "";
        }
        if (line == 12)
        {
            goodWizard.text = "";
            player.text = "...";
        }
        if (line == 13)
        {
            goodWizard.text = "What?";
            player.text = "";
        }
        if (line == 14)
        {
            goodWizard.text = "";
            player.text = "YOU THINK I CAN DEFEAT HIM WITH JUST THIS SWORD?";
        }
        if (line == 15)
        {
            goodWizard.text = "Hmm then I shall grant you fireball powers";
            player.text = "";
        }
        if (line == 16)
        {
            player.text = "REALLY? THANK YOU SO MUCH!!";
            goodWizard.text = "";
        }
        if (line == 17)
        {
            goodWizard.text = "Don't get too excited you can only use it twice or you will die";
            player.text = "";
        }
        if (line == 18)
        {
            player.text = "Oh, but why?";
            goodWizard.text = "";
        }
        if (line == 19)
        {
            player.text = "";
            goodWizard.text = "Because you're inexperienced";
        }
        if (line == 20)
        {
            player.text = "";
            goodWizard.text = "Now let me give you the Fire Gem";
        }
        if (line == 21)
        {
            player.text = "Ok";
            goodWizard.text = "";
        }
        if (line == 22)
        {
            player.text = "";
            goodWizard.text = "Where'd I put it. Ahh here it is";
        }
        if (line == 23 && (gem == 1))
        {
            player.text = "";
            goodWizard.text = "*Drops fire gem*";
            Instantiate(fireGemPrefab, fireGemSpawn.transform.position, Quaternion.identity);
            gem--;
            fireGemHb.FindFireGemPos();
        }
        if (line == 24)
        {
            player.text = "AWESOME THANKS!!";
            goodWizard.text = "";
        }
        if (line == 25)
        {
            player.text = "";
            goodWizard.text = "Yeah yeah, just dont get yourself killed out there";
        }
        if (line == 26)
        {
            player.text = "";
            goodWizard.text = "Now go save the world";
        }
        if (line == 27)
        {
            player.text = "Ok I will try my best";
            goodWizard.text = "";
        }
        if (line == 28)
        {
            player.text = "";
            goodWizard.text = "You better";
        }
        if (line == 29)
        {
            player.text = "";
            goodWizard.text = "";
            cam.FindPlayer();
        }
    }
    public void Count()
    {
        line++;
    }
}
