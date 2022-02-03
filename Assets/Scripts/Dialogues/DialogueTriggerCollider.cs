
using System.Collections;
using UnityEngine;

public class DialogueTriggerCollider : MonoBehaviour
{


    private bool playerInRange;
    public GameObject visualCue;
    public TextAsset inkJSON;
    public TextAsset inkJSON2;
    public TextAsset inkJSON3;
    public TextAsset inkJSON4;
    public TextAsset inkJSON_Undertale;

    public GameObject objet;
    public GameObject objet2;

    public bool pickupobjet1 = false;
    public bool pickupobjet2 = false;
    public bool leverFinished2 = false;

    public Collider2D colliderUndertale;
    public AudioClip soundDial;

    public bool isPioupiou = false;
    public bool isKing = false;

    private void Awake()
    {
            playerInRange = false;
            visualCue.SetActive(false);
    }


    private void Update()
    {
            if (DialogueManager.instance.newText1 == true)
            {
                if (objet != null && pickupobjet1 == false)
                {
                    objet.SetActive(true);
                    pickupobjet1 = true;
                }
            }

            if (DialogueManager.instance.newText2 == true)
            {
                if (objet2 != null && pickupobjet2 == false)
                {
                    objet2.SetActive(true);
                    pickupobjet2 = true;
                }

            }


        if (DialogueManager.instance.leverFinished == true && leverFinished2 == false)
            {
                StartCoroutine(FinishUndertale());
            }


        if (playerInRange && !DialogueManager.instance.dialogueIsPlaying)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {


                if (isPioupiou)
                {

                    if (Inventory.instance.chocolat == 0 && Inventory.instance.fraises == 0 && DialogueManager.instance.newText1 == false)

                        DialogueManager.instance.EnterDialogueMode(inkJSON);

                    else if (Inventory.instance.chocolat == 0 && Inventory.instance.fraises == 0 && DialogueManager.instance.newText1 == true && DialogueManager.instance.newText2 == false)

                        DialogueManager.instance.EnterDialogueMode(inkJSON2);

                    else if (Inventory.instance.chocolat == 0 && Inventory.instance.fraises == 0 && DialogueManager.instance.newText1 == true && DialogueManager.instance.newText2 == true)

                        DialogueManager.instance.EnterDialogueMode(inkJSON3);

                    else if (Inventory.instance.chocolat == 1 && Inventory.instance.fraises == 0 && DialogueManager.instance.newText2 == false)
                        DialogueManager.instance.EnterDialogueMode(inkJSON2);

                    else if (Inventory.instance.chocolat == 1 && Inventory.instance.fraises == 0 && DialogueManager.instance.newText2 == true)
                        DialogueManager.instance.EnterDialogueMode(inkJSON3);

                    else if (Inventory.instance.chocolat == 1 && Inventory.instance.fraises == 1)
                        DialogueManager.instance.EnterDialogueMode(inkJSON3);

                }


                if (isKing)
                {
                    if (DialogueManager.instance.newText1 == false && Inventory.instance.farine == 0 && Inventory.instance.beurre == 0)
                    {

                        DialogueManager.instance.EnterDialogueMode(inkJSON);


                    }
                    
                    else

                    {
                        DialogueManager.instance.EnterDialogueMode(inkJSON2);
                    }

                }

            }

        }


        else
        {
            visualCue.SetActive(false);
        }
      
    }

    IEnumerator FinishUndertale()
    {
        leverFinished2 = true;
        yield return new WaitForSeconds(2f);
        PlayerMovement.instance.isFreezed = false;
        colliderUndertale.enabled = false;
        DialogueManager.instance.EnterDialogueMode(inkJSON_Undertale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            playerInRange = false;
            visualCue.SetActive(false);
        }
    }

}
