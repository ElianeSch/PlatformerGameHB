using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{

    public string nameOfScene;
    public Animator fadeSystem;
    public SpriteRenderer sprite;

    public static LoadSpecificScene instance;
    public bool canGo = false;

    public AudioClip soundPorte;
    public AudioClip soundPorte2;

    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        if (instance != null)
        {
            Debug.Log("Plus d'une instance de LoadSpecificScene dans la scène");
        }

        instance = this;
    }

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if(collision.CompareTag("Player") && (Inventory.instance.objectPicked >= CurrentSceneManager.instance.objectsToPick))
        {
            //AudioManager.instance.audioSource.Stop();
            AudioManager.instance.PlayClipAt(soundPorte, transform.position);

            StartCoroutine(LoadNextScene());
        }
    }


    public IEnumerator LoadNextScene()
    {

        LoadAndSaveData.instance.SaveData();
        PlayerMovement.instance.isFreezed = true;
        yield return new WaitForSeconds(0.5f);
      
        AudioManager.instance.PlayClipAt(soundPorte2,transform.position);
        sprite.color = Color.black;
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        PlayerMovement.instance.isFreezed = false;
        SceneManager.LoadScene(nameOfScene);

        
    }

}

