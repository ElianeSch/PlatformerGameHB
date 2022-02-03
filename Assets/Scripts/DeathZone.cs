using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Animator fadeSystem;
    public AudioClip sound;
    private void Awake()
    {
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(collision));
           
        }
    }



    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        AudioManager.instance.PlayClipAt(sound, transform.position);
        PlayerMovement.instance.isFreezed = true;
        PlayerMovement.instance.GetComponent<Animator>().SetTrigger("isFalling");
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = CurrentSceneManager.instance.respawnPoint;
        yield return new WaitForSeconds(1f);
        PlayerMovement.instance.isFreezed = false;

        //PlayerMovement.instance.GetComponent<Animator>().enabled = true;


    }

}
