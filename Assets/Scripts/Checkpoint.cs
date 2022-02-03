using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    public AudioClip sound;
    private void Awake()
    {
        
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            CurrentSceneManager.instance.respawnPoint = transform.position;
            animator.SetTrigger("Checked");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
