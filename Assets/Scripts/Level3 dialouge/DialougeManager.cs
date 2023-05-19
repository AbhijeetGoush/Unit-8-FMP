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
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        wizardDialouge = tmp.GetComponent<EvilWizardDialouge>();
    }

    // Update is called once per frame
    void Update()
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
                Destroy(dialougeBarrier2Obj);
            }
        }

    }


}
