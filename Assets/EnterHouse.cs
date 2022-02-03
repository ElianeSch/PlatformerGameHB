using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouse : MonoBehaviour
{

    public Animator fadeSystem;
    public AudioClip sound;
    public AudioClip sound2;
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Enter the house");
            StartCoroutine(LoadNextScene());
        }
    }

    public IEnumerator LoadNextScene()
    {
        AudioManager.instance.PlayClipAt(sound, transform.position);
        LoadAndSaveData.instance.SaveData();
        PlayerMovement.instance.isFreezed = true;
        yield return new WaitForSeconds(0.5f);
        fadeSystem.SetTrigger("FadeIn");
        AudioManager.instance.PlayClipAt(sound2, transform.position);
        yield return new WaitForSeconds(1f);
        PlayerMovement.instance.isFreezed = false;
        SceneManager.LoadScene("End");


    }
}
