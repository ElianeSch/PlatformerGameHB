using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public TextAsset inkJSON;

    private void Start()
    {
        DialogueManager.instance.EnterDialogueMode(inkJSON);
        
    }
}
