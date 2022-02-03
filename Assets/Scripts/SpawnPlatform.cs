using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class SpawnPlatform : MonoBehaviour
{

    public GameObject[] listPlatforms;
    public List<SpriteRenderer> listSprites;
    public List<Collider2D> listColliders;
    public float time;
    public AudioClip sound;
    public bool canHear = false;

    private void Awake()
    {
        for (int i = 0; i < listPlatforms.Length; i++)
        {
            listColliders.Add(listPlatforms[i].GetComponent<BoxCollider2D>());
            listSprites.Add(listPlatforms[i].GetComponent<SpriteRenderer>());
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < listPlatforms.Length; i++)
        {
            Color tmp1 = listSprites[i].color;

            if (i % 2 == 0)
            {
                listSprites[i].color = tmp1;
            }

            else
            {
                tmp1.a = 0.2f;
                listSprites[i].color = tmp1;
                listColliders[i].enabled = false;
            }


        }
        StartCoroutine(MakePlatformsSpawn());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canHear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canHear = false;
    }


    IEnumerator MakePlatformsSpawn()
    {

        while (true)
        {



            for (int i = 0; i < listPlatforms.Length; i++)
            {
                Color tmp1 = listSprites[i].color;

                if (tmp1.a == 0.2f)
                {
                    tmp1.a = 1f;
                }
                else
                {
                    tmp1.a = 0.2f;
                }

                listSprites[i].color = tmp1;

                listColliders[i].enabled = !listColliders[i].enabled;

            }

            if(canHear)
            {
                AudioManager.instance.PlayClipAt(sound, transform.position);
            }
            
            yield return new WaitForSeconds(time);
        }
       
    }


}
