
using UnityEngine;
using TMPro;
using Ink.Runtime;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using System;
public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;

    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI displayNameText;

    public Animator portraitAnimator;
    public Animator boxAnimator;

    public Animator layoutAnimator;

    private Story currentStory;
    public bool dialogueIsPlaying;

    public GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string NEW_TEXT_TAG = "newtext";
    private const string LEVER_TAG = "lever";
    private const string CAM_TAG = "cam";
    private const string PIOUPIOU_TAG = "perso";


    bool phraseTerminee = true;
    public bool newText1 = false;
    public bool newText2 = false;
    public bool newText3 = false;
    public bool leverDown = false;
    public bool leverFinished = false;
    public bool camUnder = false;
    public bool defiUndertale = false;
    public bool pioupiou = false;

    public GameObject crankup;
    public GameObject crankdown;

    public AudioClip sound1;
    public AudioClip sound2;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one instance of Dialogue Manager in the scene");
        }

        instance = this;
    }

    private void Start()
    {
        
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];

        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }


    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }


        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }


    public void EnterDialogueMode(TextAsset inkJSON)
    {

        //AudioManager.instance.PlayClipAt(sound, PlayerMovement.instance.transform.position);

        currentStory = new Story(inkJSON.text);
        boxAnimator.SetBool("isOpen", true);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        PlayerMovement.instance.isFreezed = true;

        displayNameText.text = "???";
        portraitAnimator.Play("default");
        //layoutAnimator.Play("left");
        //AudioManager.instance.PlayClipAt(sound, PlayerMovement.instance.transform.position);
        ContinueStory();

    }


    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (phraseTerminee)
            {
                dialogueText.text = currentStory.Continue();
                HandleTags(currentStory.currentTags);
                StartCoroutine(TypeSentence(dialogueText.text));
                DisplayChoices();

            }

        }

        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }


    IEnumerator TypeSentence(string sentence)
    {

        
        phraseTerminee = false;
        dialogueText.text = "";
        int r = 0;
        foreach (char letter in sentence.ToCharArray())
        {
            
            int myRandomIndex = UnityEngine.Random.Range(0, 1);
            AudioClip sound;
            if (myRandomIndex ==1)
            {
                sound = sound1;
            }
            else
            {
                sound = sound2;
            }
            if (r%4 == 0)
            {
                AudioManager.instance.PlayClipAt(sound, transform.position);
                //yield return new WaitForSeconds(sound.length / 2);
            }

            
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
            r = r + 1;
        }
        phraseTerminee = true;
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag de longueur incorrecte : " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;

                    break;

                case PORTRAIT_TAG:

                    portraitAnimator.Play(tagValue);

                    break;

                case NEW_TEXT_TAG:

                
                    if (tagValue == "1")
                    {
                        newText1 = true;

                    }

                    else if (tagValue == "2")
                    {
                        newText2 = true;
                    }

                    else if (tagValue == "3")
                    {
                        newText3 = true;
                    }
                    break;

                case LEVER_TAG:
                    newText1 = true;
                    defiUndertale = true;
                    StartCoroutine(leverDownFunc());
                    
                    //leverDown = true;
                    break;


                case CAM_TAG:

                    {
                        camUnder = true;
                        break;
                    }
                case LAYOUT_TAG:


                    if (tagValue == "left")
                    {
                        layoutAnimator.SetTrigger("left");
                    }
                    else
                    {
                        layoutAnimator.SetTrigger("right");
                    }

                    break;

                case PIOUPIOU_TAG:
                    pioupiou = true;
                    break;
                    

                default:
                    Debug.LogWarning("Tag came in but is not currently being handled : " + tag);
                    break;

            }

        }
    }


    IEnumerator leverDownFunc()
    {
        PlayerMovement.instance.isFreezed = true;
        crankup.SetActive(false);
        crankdown.SetActive(true);
        yield return new WaitForSeconds(2f);
        leverDown = true;
    }



    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too many choices, can't show all the choices");
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }


        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {

        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }


    public IEnumerator ExitDialogueMode()
    {
        boxAnimator.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.4f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        if (defiUndertale == false)
            PlayerMovement.instance.isFreezed = false;
        else
            defiUndertale = false;
    }










}
