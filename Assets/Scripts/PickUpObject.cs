using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public string nameObject; //nom de l'objet qu'on a ramassé

    public AudioClip sound;
    public AudioClip soundBallon;
    public AudioClip soundIngredient;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (nameObject == "Ballon")
            {
                AudioManager.instance.PlayClipAt(soundBallon, transform.position);
                Inventory.instance.AddBalloons(1);

            }

            else if (nameObject == "Coin")
            {
                AudioManager.instance.PlayClipAt(sound, transform.position);
                Inventory.instance.AddCoins(1);
            }

            else if (nameObject == "Fraises")
            {
                Inventory.instance.fraises = 1;
                AudioManager.instance.PlayClipAt(soundIngredient, transform.position);

            }

            else if (nameObject == "Chantilly")
            {
                Inventory.instance.chantilly = 1;
                AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
            }

            else if (nameObject == "Billes")
            {
                Inventory.instance.billes = 1;
                AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
            }

            else if (nameObject == "Chocolat")
            {
                if (Inventory.instance.chocolat == 0)
                {
                    AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
                    Inventory.instance.chocolat = 1;
                    Inventory.instance.objectPicked += 1;
                }


            }

            else if (nameObject == "Beurre")
            {
                if (Inventory.instance.beurre == 0)
                {
                    AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
                    Inventory.instance.beurre = 1;
                    Inventory.instance.objectPicked += 1;
                }
            }

            else if (nameObject == "Sucre")
            {
                if (Inventory.instance.sucre == 0)
                {
                    AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
                    Inventory.instance.sucre = 1;
                    Inventory.instance.objectPicked += 1;
                }
            }

            else if (nameObject == "Farine")
            {
                if (Inventory.instance.farine == 0)
                {
                    AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
                    Inventory.instance.farine = 1;
                    Inventory.instance.objectPicked += 1;
                }
            }

            else if (nameObject == "Oeufs")
            {
                if (Inventory.instance.oeufs == 0)
                {
                    AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
                    Inventory.instance.oeufs = 1;
                    Inventory.instance.objectPicked += 1;
                }
            }

            else if (nameObject == "Bougies")
            {
                if (Inventory.instance.bougie == 0)
                {
                    AudioManager.instance.PlayClipAt(soundIngredient, transform.position);
                    Inventory.instance.bougie = 1;
                    Inventory.instance.objectPicked += 1;
                }
            }

            else
            {
                Debug.Log("Objet non reconnu :" + nameObject);
            }


            InventoryUI.instance.UpdateUI(nameObject);
            Destroy(gameObject);

        }
    }








}
