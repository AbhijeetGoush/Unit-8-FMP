using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeManager : MonoBehaviour
{
    EvilWizardDialouge wizardDialouge;
    public GameObject tmp;
    public Transform dialougeBarrier1;
    public GameObject dialougeBarrier1Obj;
    public Transform dialougeBarrier2;
    public GameObject dialougeBarrier2Obj;
    public Transform dialougeBarrier3;
    public GameObject dialougeBarrier3Obj;
    public Transform dialougeBarrier4;
    public GameObject dialougeBarrier4Obj;
    public Transform dialougeBarrier5;
    public GameObject dialougeBarrier5Obj;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        wizardDialouge = tmp.GetComponent<EvilWizardDialouge>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( player != null )
        {
            if (dialougeBarrier1 != null)
            {
                if (player.transform.position.x > dialougeBarrier1.transform.position.x)
                {
                    wizardDialouge.line = 1;
                    Destroy(dialougeBarrier1Obj);
                }
            }

            if (dialougeBarrier2 != null)
            {
                if (player.transform.position.x > dialougeBarrier2.transform.position.x)
                {
                    wizardDialouge.line = 2;
                    Destroy(dialougeBarrier2Obj);
                }
            }

            if (dialougeBarrier3 != null)
            {
                if (player.transform.position.x > dialougeBarrier3.transform.position.x)
                {
                    wizardDialouge.line = 3;
                    Destroy(dialougeBarrier3Obj);
                }
            }

            if (dialougeBarrier4 != null)
            {
                if (player.transform.position.y < dialougeBarrier4.transform.position.y)
                {
                    wizardDialouge.line = 4;
                    Destroy(dialougeBarrier4Obj);
                }
            }

            if (dialougeBarrier5 != null)
            {
                if (player.transform.position.x > dialougeBarrier5.transform.position.x)
                {
                    wizardDialouge.line = 5;
                    Destroy(dialougeBarrier5Obj);
                }
            }
        }

    }


}
