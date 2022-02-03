using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Calendrier : MonoBehaviour
{
    public static Calendrier instance;
    private int index = -1;
    public string[] messages;
    public List<Button> listButtons;
    public GameObject im;
    private TextMeshProUGUI textUI;

    private void Awake()
    {
        im.SetActive(false);
        textUI = im.GetComponentInChildren<TextMeshProUGUI>();

    }



    public void PrintMessage()
    {
        StopAllCoroutines();
        StartCoroutine(PrintM());
    }

    public IEnumerator PrintM()
    {
        im.SetActive(true);
        index += 1;
        if (index > messages.Length-1)
            index = messages.Length-1;
        textUI.text = messages[index];
        yield return new WaitForSeconds(1.5f);
        im.SetActive(false);
    }

    public void LoadLevel()
    {
        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached",1))
        {
            PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
        }
        
        SceneManager.LoadScene("Intro2");
    }

}
