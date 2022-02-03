using UnityEngine;

public class Mushroom : MonoBehaviour
{

    public Animator mushroomAnimator;
    public AudioClip sound;
    public float force;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            mushroomAnimator.SetTrigger("MushroomJump");
            PlayerMovement.instance.jumpMushroom = true;
            PlayerMovement.instance.rb.velocity = new Vector2(PlayerMovement.instance.rb.velocity.x, 0);
            PlayerMovement.instance.rb.AddForce(Vector2.up * PlayerMovement.instance.jumpSpeed*force, ForceMode2D.Impulse);
            PlayerMovement.instance.ApplyAirLinearDragMushroom();
            PlayerMovement.instance.FallMultiplierMushroom();
            print("Done");
        }
    }

}
