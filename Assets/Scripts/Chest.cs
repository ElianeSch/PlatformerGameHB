using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public bool canOpenChest = false;
    public bool chestOpen = false;
    public Animator chestAnimator;
    public int numberCoins;
    public GameObject coinPrefab;
    public float ecartX;
    public float ecartY;

    public GameObject recompense;
    public GameObject visualBox;

    private Vector3 chestPos;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip soundRecompense;

    private void Start()
    {
        chestPos = transform.position;
        ecartX = coinPrefab.transform.localScale.x;
        ecartY = coinPrefab.transform.localScale.y;
        visualBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && chestOpen == false)
        {
            canOpenChest = true;
            visualBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpenChest = false;
            visualBox.SetActive(false);
        }
    }

    private void Update()
    {
        if (canOpenChest && Input.GetKeyDown(KeyCode.A))
        {
            chestOpen = true;
            chestAnimator.SetBool("chestOpen", true);
            StartCoroutine(OpenChest());
           
        }
    }


    public IEnumerator OpenChest()
    {
        AudioManager.instance.PlayClipAt(sound1,transform.position);
        yield return new WaitForSeconds(1f);
        int j = 1;
        for (int i=0;i<numberCoins;i++)
            {
                Instantiate(coinPrefab, new Vector3(chestPos.x + i*ecartX, chestPos.y + j*ecartY, chestPos.z), Quaternion.identity);

                if (j==0)
                    {
                        j = 1;
                    }
                else
                    {
                        j = 0;
                    }
            }

        if (recompense == null)
        {
            AudioManager.instance.PlayClipAt(sound2, transform.position);
        }

        
        if (recompense !=null)
        {
            AudioManager.instance.PlayClipAt(soundRecompense, transform.position);
            recompense.SetActive(true);
        }
        
    }


}
