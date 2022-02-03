using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defiUndertale : MonoBehaviour
{
    public bool isDown = false;
    public SpriteRenderer[] listeTiles;
    public Color[] listColor;
    public AudioClip click;
    public AudioClip sound;


    void Update()

    {

        if (DialogueManager.instance.leverDown == true && isDown == false)
        {
            isDown = true;
            
            Debug.Log("LE LEVIER EST ABAISSE");
            AudioManager.instance.PlayClipAt(click, transform.position);
            AudioManager.instance.audioSource.Stop();
            //PlayerMovement.instance.isFreezed = true;
            StartCoroutine(PiegeUndertale());
        }

    }

    IEnumerator PiegeUndertale()
    {

        AudioManager.instance.audioSource.Stop();
        AudioManager.instance.PlayClipAt(sound, transform.position);
        PlayerMovement.instance.isFreezed = true;
        for (int j=0;j<40;j++)
        {
            for (int i = 0; i < listeTiles.Length; i++)
            {
                listeTiles[i].color = listColor[Random.Range(0, listColor.Length)];

            }
            yield return new WaitForSeconds(0.15f);
        }

        for (int i =0;i < listeTiles.Length;i++)
        {
            listeTiles[i].color = listColor[5];
        }



        DialogueManager.instance.leverFinished = true;
        AudioManager.instance.audioSource.Play();
        //PlayerMovement.instance.isFreezed = false;
    }

}
