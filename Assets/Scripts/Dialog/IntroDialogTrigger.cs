using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogTrigger : MonoBehaviour
{
    DialogueTrigger dTrigger;
    // Start is called before the first frame update
    void Start()
    {
        dTrigger = gameObject.GetComponent<DialogueTrigger>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dTrigger.TriggerDialogue();
        }
    }
}
