using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CakeAppear : MonoBehaviour
{
    public SpriteRenderer[] listeIngredients;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;

    public GameObject[] listeBallon;
    public Animator fadeSystem;

    private void Awake()
    {
        for (int i=0;i<listeIngredients.Length;i++)
        {
            listeIngredients[i].enabled = false;
        }
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cake());
    }



    IEnumerator Cake()
    {
        AudioManager.instance.audioSource.Stop();
        yield return new WaitForSeconds(2f);

        AudioManager.instance.PlayClipAt(sound1, transform.position);
        yield return new WaitForSeconds(1.5f);

        AudioManager.instance.PlayClipAt(sound2, transform.position);
        yield return new WaitForSeconds(1.5f);

        AudioManager.instance.PlayClipAt(sound3, transform.position);
        yield return new WaitForSeconds(2f);

        AudioManager.instance.PlayClipAt(sound4, transform.position);

        yield return new WaitForSeconds(4f);
        AudioManager.instance.audioSource.Play();
        listeIngredients[0].enabled = true;
        yield return new WaitForSeconds(2f);


     


        if (Inventory.instance.fraises == 1)
        {
            listeIngredients[2].enabled = true;
            yield return new WaitForSeconds(1.5f);
        }

        if (Inventory.instance.chantilly == 1)
        {
            listeIngredients[3].enabled = true;
            yield return new WaitForSeconds(1.5f);
        }


        if (Inventory.instance.billes ==1)
        {
            listeIngredients[4].enabled = true;
            yield return new WaitForSeconds(1.5f);
        }

        if (Inventory.instance.coulis == 1)
        {
            listeIngredients[5].enabled = true;
            yield return new WaitForSeconds(1.5f);
        }

        if (Inventory.instance.bougie == 1)
        {
            listeIngredients[1].enabled = true;
            yield return new WaitForSeconds(1.5f);
        }


        fadeSystem.SetTrigger("FadeIn");

        yield return new WaitForSeconds(2f);



        for (int i=0;  i< Mathf.Min(Inventory.instance.ballonsCount, listeBallon.Length);i++)
        {
            listeBallon[i].SetActive(true);
        }

        yield return new WaitForSeconds(10f);

        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Credits");
    }


}
