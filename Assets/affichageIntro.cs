using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class affichageIntro : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    bool phraseTerminee = true;
    private Story currentStory;
    public TextMeshProUGUI displayNameText;
    public TextAsset inkJSON;
    public Animator portraitAnimator;
    public Animator fadeSystem;

    public TextMeshProUGUI texteIntro;

    [TextArea(10,10)]
    public string texte;
    public string texte2;
    public string texte3;
    public string texte4;
    public string texte5;

    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LEVEL_TAG = "level";

    public bool canContinue = false;
    public bool calendrier = false;

    private void Awake()
    {

        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        if (calendrier)
            StartCoroutine(Enter());
        else
        {
            EnterDialogueMode(inkJSON);
            canContinue = true;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && canContinue)
        {
            ContinueStory();
        }
    }


    IEnumerator Enter()
    {
        yield return new WaitForSeconds(2f);


        texteIntro.text = "";
        foreach (char letter in texte.ToCharArray())
        {
            texteIntro.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);

        texteIntro.text = "";

        foreach (char letter in texte2.ToCharArray())
        {
            texteIntro.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);

        texteIntro.text = "";

        foreach (char letter in texte3.ToCharArray())
        {
            texteIntro.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);

        texteIntro.text = "";

        foreach (char letter in texte4.ToCharArray())
        {
            texteIntro.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(2f);


        texteIntro.text = "";

        foreach (char letter in texte5.ToCharArray())
        {
            texteIntro.text += letter;
            yield return new WaitForSeconds(0.02f);
        }


        yield return new WaitForSeconds(2f);

        fadeSystem.SetTrigger("FadeIn");
        texteIntro.enabled = false;
        yield return new WaitForSeconds(1f);
        
        EnterDialogueMode(inkJSON);
        canContinue = true;

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {

        //AudioManager.instance.PlayClipAt(sound, PlayerMovement.instance.transform.position);

        currentStory = new Story(inkJSON.text);
        dialoguePanel.SetActive(true);
        displayNameText.text = "???";
        portraitAnimator.Play("default");
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

            }

        }

        else
        {
            if (calendrier)
                StartCoroutine(LoadCalendrier());
            else
                StartCoroutine(LoadLevel1());
        }
    }





    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
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

                case LEVEL_TAG:
                    calendrier = true;
                    break;


                default:
                    Debug.LogWarning("Tag came in but is not currently being handled : " + tag);
                    break;

            }

        }
    }








    IEnumerator LoadCalendrier()
    {

        yield return new WaitForSeconds(0.5f);
        //LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Calendrier");
    }

    IEnumerator LoadLevel1()
    {

        yield return new WaitForSeconds(1.5f);
        //LoadAndSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level01");
    }
    IEnumerator TypeSentence(string sentence)
    {
        phraseTerminee = false;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        phraseTerminee = true;

    }
}
