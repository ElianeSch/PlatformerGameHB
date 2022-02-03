
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public static InventoryUI instance;
    public GameObject inventairePanel;
    public GameObject itemsBasiques;
    public GameObject itemsBonus;
    public GameObject backpack;
    public GameObject backpackOpen;
    public Image imageBackpack;
    public Image imageBackpackOpen;
    public bool inventoryOpen = false;
    public GameObject imageFraise;
    public GameObject imageChantilly;
    public GameObject imageBilles;
    public GameObject imageCoulis;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        inventairePanel = GameObject.Find("Inventaire");
        backpack = GameObject.Find("Backpack");
        backpackOpen = GameObject.Find("BackpackOpen");
        imageBackpack = backpack.GetComponent<Image>();
        imageBackpackOpen = backpackOpen.GetComponent<Image>();
        itemsBasiques = GameObject.Find("ItemsBasiques");
        itemsBonus = GameObject.Find("ItemsBonus");
        inventairePanel.SetActive(false);

    }

    private void Start()
    {
        inventairePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && DialogueManager.instance.dialogueIsPlaying == false)
        {
            PlayerMovement.instance.isFreezed = !PlayerMovement.instance.isFreezed;
            inventairePanel.SetActive(!inventairePanel.activeSelf);
            inventoryOpen = !inventoryOpen;
            imageBackpack.enabled = !imageBackpack.enabled;
            imageBackpackOpen.enabled = !imageBackpackOpen.enabled;
        }
    }


    public void UpdateUI(string nameObject)
    {

        if (nameObject == "Ballon")
        {
            GameObject slot = itemsBonus.transform.Find(nameObject).gameObject;
            GameObject texte = slot.transform.GetChild(1).gameObject;
            Text txt = texte.GetComponent<Text>();
            txt.text = "x  " + (Inventory.instance.ballonsCount).ToString();
        }


        else if (nameObject == "Coin")
        {
            GameObject slot = itemsBonus.transform.Find(nameObject).gameObject;
            GameObject texte = slot.transform.GetChild(1).gameObject;
            Text txt = texte.GetComponent<Text>();
            txt.text = "x  " + (Inventory.instance.coinsCount).ToString();
        }

        else if (nameObject == "Fraises")
        {

            imageFraise.SetActive(true);
        }

        else if (nameObject == "Chantilly")
        {

            imageChantilly.SetActive(true);
        }

        else if (nameObject == "Billes")
        {
            Debug.Log("coucou les billes");
            imageBilles.SetActive(true);
        }


        else if (nameObject == "Coulis")
        {
            imageCoulis.SetActive(true);
        }

        else
        {
            GameObject slot = itemsBasiques.transform.Find(nameObject).gameObject;
            GameObject image = slot.transform.GetChild(0).gameObject;
            Image im = image.GetComponentInChildren<Image>();
            im.enabled = true;
        }


    }
}
