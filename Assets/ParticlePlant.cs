using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlant : MonoBehaviour
{
    public ParticleSystem particlesSys;
    private bool canContinue = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canContinue == false)
        {
            particlesSys.Stop();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            particlesSys.Play();
            canContinue = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            canContinue = false;
    }
}
