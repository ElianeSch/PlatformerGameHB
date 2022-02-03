
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    public GameObject visualCue;
    public GameObject ShopPanel;
    public bool playerInRange;

    public GameObject imageBouton1;
    public GameObject imageBouton2;
    public GameObject imageBouton3;
    public GameObject imageBouton4;

    public GameObject merciImage;
    public Text texteImage;
    public Text texteMerci;
    public Text texteDommage;
    public Text texteDeja;

    public bool click1 = false;
    public bool click2 = false;
    public bool click3 = false;
    public bool click4 = false;

    public AudioClip sound;


    void Start()
    {
        merciImage.SetActive(false);
        visualCue.SetActive(false);
        texteMerci.enabled = false;
        texteDommage.enabled = false;
        texteDeja.enabled = false;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.A))
        {

            ShopPanel.SetActive(!ShopPanel.activeSelf);
            
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            playerInRange = false;
            visualCue.SetActive(false);
            ShopPanel.SetActive(false);
            

        }
    }



    public void Bouton1(int cout)
    {
        if (Inventory.instance.coinsCount >= cout && Inventory.instance.billes == 0)
        {
            Inventory.instance.billes = 1;
            Inventory.instance.AddCoins(-cout);
            InventoryUI.instance.UpdateUI("Coin");
            InventoryUI.instance.UpdateUI("Billes");
            AudioManager.instance.PlayClipAt(sound, transform.position);
            StartCoroutine(Merci());

        }

        else
        {
            if (Inventory.instance.billes == 1)
            {
                StartCoroutine(Deja());
            }

            else
                StartCoroutine(Dommage());
        }
    }

    public void Bouton2(int cout)
    {
        if (Inventory.instance.coinsCount >= cout && Inventory.instance.fraises ==0)
        {
            Inventory.instance.fraises = 1;
            Inventory.instance.AddCoins(-cout);
            InventoryUI.instance.UpdateUI("Coin");
            InventoryUI.instance.UpdateUI("Fraises");
            AudioManager.instance.PlayClipAt(sound, transform.position);
            StartCoroutine(Merci());

        }

        else
        {
            if (Inventory.instance.fraises == 1)
            {
                StartCoroutine(Deja());
            }

            else
                StartCoroutine(Dommage());
        }
    }

    public void Bouton3(int cout)
    {
        if (Inventory.instance.coinsCount >= cout && Inventory.instance.chantilly == 0)
        {
            Inventory.instance.chantilly= 1;
            Inventory.instance.AddCoins(-cout);
            InventoryUI.instance.UpdateUI("Coin");
            InventoryUI.instance.UpdateUI("Chantilly");
            AudioManager.instance.PlayClipAt(sound, transform.position);
            StartCoroutine(Merci());
        }

        else
        {
            if (Inventory.instance.chantilly == 1)
            {
                StartCoroutine(Deja());
            }

            else
                StartCoroutine(Dommage());
        }
    }

    public void Bouton4(int cout)
    {
        if (Inventory.instance.coinsCount >= cout && Inventory.instance.coulis == 0)
        {
            Inventory.instance.coulis = 1;
            Inventory.instance.AddCoins(-cout);
            InventoryUI.instance.UpdateUI("Coin");
            InventoryUI.instance.UpdateUI("Coulis");
            AudioManager.instance.PlayClipAt(sound, transform.position);
            StartCoroutine(Merci());
        }
        else
        {
            if (Inventory.instance.coulis == 1)
            {
                StartCoroutine(Deja());
            }

            else
                StartCoroutine(Dommage());
        }
    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
    }

    public IEnumerator Merci()
    {
        merciImage.SetActive(true);
        texteImage.text = texteMerci.text;
        yield return new WaitForSeconds(1.5f);
        merciImage.SetActive(false);
    }

    public IEnumerator Dommage()
    {
        merciImage.SetActive(true);
        texteImage.text = texteDommage.text;
        yield return new WaitForSeconds(1.5f);
        merciImage.SetActive(false);
    }

    public IEnumerator Deja()
    {
        merciImage.SetActive(true);
        texteImage.text = texteDeja.text;
        yield return new WaitForSeconds(1.5f);
        merciImage.SetActive(false);

    }

}
