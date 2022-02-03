using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanneauIndic : MonoBehaviour
{

    public GameObject visualBox;
    private BoxCollider2D collider;
    public bool inRange;
    public bool isReading;
    private GameObject pannelPanneau;
    [TextArea(5, 10)]
    public string textToDisplay;
    private Text textPannel;

    private void Awake()
    {
        collider = GetComponentInChildren<BoxCollider2D>();
        pannelPanneau = GameObject.Find("PannelIndic");
        textPannel = pannelPanneau.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        visualBox.SetActive(false);
        pannelPanneau.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && inRange && !isReading)
        {
            isReading = true;
        }

        else if (Input.GetKeyDown(KeyCode.A) && isReading)
            {
                isReading = false;
                pannelPanneau.SetActive(false);
        }


        if (isReading)
        {
            pannelPanneau.SetActive(true);
            textPannel.text = textToDisplay;
            Debug.Log("Ceci est un message");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualBox.SetActive(true);
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            visualBox.SetActive(false);
            inRange = false;
            isReading = false;
            pannelPanneau.SetActive(false);
        }
    }

}
