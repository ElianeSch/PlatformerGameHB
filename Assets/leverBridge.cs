using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverBridge : MonoBehaviour
{

    public Animator animLever;
    public bool canDownLever;
    public GameObject visualClue;
    public bool leverDown = false;
    public GameObject bridgeComponent;
    private float size;
    public int numberComponents;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {

        size = bridgeComponent.GetComponent<SpriteRenderer>().bounds.size.x;

        visualClue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.A) && canDownLever)
        {
            animLever.SetTrigger("leverDown");
            leverDown = true;
            StartCoroutine(MakeBridge(numberComponents));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (leverDown == false)
            {
                canDownLever = true;
                visualClue.SetActive(true);
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canDownLever = false;
            visualClue.SetActive(false);
        }
    }

    IEnumerator MakeBridge(int numberComponents)
    {
        for (int i=0;i<numberComponents;i++)
        {
            bridgeComponent.SetActive(true);
            Instantiate(bridgeComponent, new Vector3(bridgeComponent.transform.position.x + size* i, bridgeComponent.transform.position.y, 0), Quaternion.identity);
            AudioManager.instance.PlayClipAt(sound, transform.position);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
