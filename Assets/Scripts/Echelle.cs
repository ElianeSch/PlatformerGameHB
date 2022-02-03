
using UnityEngine;

public class Echelle : MonoBehaviour
{
    public bool canClimb;

    public BoxCollider2D colliderEche;
    public Animator animator;
    public GameObject visualBox;
    public float offset;

    private void Awake()
    {
        visualBox.SetActive(false);
    }

    private void Update()
    {
        if (canClimb && PlayerMovement.instance.isClimbing && Input.GetKeyDown(KeyCode.A))
        {
            // Si on a commencé à monter mais que finalement on ne veut pas
            PlayerMovement.instance.isClimbing = false;
            colliderEche.isTrigger = false;
            animator.SetBool("isClimbing", false);
            PlayerMovement.instance.rb.gravityScale = 1f;
            return;
        }




        if (Input.GetKeyDown(KeyCode.A) && canClimb)
        {
            {
                PlayerMovement.instance.isClimbing = true;
                PlayerMovement.instance.transform.position = new Vector3(transform.position.x - offset, PlayerMovement.instance.transform.position.y, PlayerMovement.instance.transform.position.z);
                animator.SetBool("isClimbing", true);
                colliderEche.isTrigger = true;
                PlayerMovement.instance.rb.gravityScale = 0f;
            }

        }



       



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           
            canClimb = true;
            visualBox.SetActive(true);
           
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))            
        {
            canClimb = false;
            PlayerMovement.instance.isClimbing = false;
            animator.SetBool("isClimbing", false);
            colliderEche.isTrigger = false;
            visualBox.SetActive(false);
            PlayerMovement.instance.rb.gravityScale = 1f;
        }
    }
}
