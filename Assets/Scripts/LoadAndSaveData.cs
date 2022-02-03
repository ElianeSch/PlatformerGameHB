using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;

    AudioSource audioSource;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de LoadAndSaveData dans la scène");
        }

        instance = this;
    }




    void Start()
    {
       
        audioSource = AudioManager.instance.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            print("Pas d'audioSource !");
        }

            Inventory.instance.coinsCount = PlayerPrefs.GetInt("coins", 0);
            Inventory.instance.ballonsCount = PlayerPrefs.GetInt("ballons", 0);
            Inventory.instance.chocolat = PlayerPrefs.GetInt("chocolat", 0);
            Inventory.instance.farine = PlayerPrefs.GetInt("farine", 0);
            Inventory.instance.oeufs = PlayerPrefs.GetInt("oeufs", 0);
            Inventory.instance.sucre = PlayerPrefs.GetInt("sucre", 0);
            Inventory.instance.beurre = PlayerPrefs.GetInt("beurre", 0);
            Inventory.instance.bougie = PlayerPrefs.GetInt("bougies", 0);

            Inventory.instance.objectPicked = PlayerPrefs.GetInt("objectPicked", 0);

            Inventory.instance.fraises = PlayerPrefs.GetInt("fraises", 0);
            Inventory.instance.chantilly = PlayerPrefs.GetInt("chantilly", 0);
            Inventory.instance.billes = PlayerPrefs.GetInt("billes", 0);
            Inventory.instance.coulis = PlayerPrefs.GetInt("coulis", 0);


            InventoryUI.instance.UpdateUI("Coin");
            InventoryUI.instance.UpdateUI("Ballon");

            if (Inventory.instance.chocolat == 1)
            {
                InventoryUI.instance.UpdateUI("Chocolat");
            }
            if (Inventory.instance.beurre == 1)
            {
                InventoryUI.instance.UpdateUI("Beurre");
            }

            if (Inventory.instance.sucre == 1)
            {
                InventoryUI.instance.UpdateUI("Sucre");
            }

            if (Inventory.instance.farine == 1)
            {
                InventoryUI.instance.UpdateUI("Farine");
            }

            if (Inventory.instance.oeufs == 1)
            {
                InventoryUI.instance.UpdateUI("Oeufs");
            }

            if (Inventory.instance.bougie == 1)
            {
                InventoryUI.instance.UpdateUI("Bougies");
            }





            if (Inventory.instance.fraises == 1)
            {
                InventoryUI.instance.UpdateUI("Fraises");
            }


            if (Inventory.instance.chantilly == 1)
            {
                InventoryUI.instance.UpdateUI("Chantilly");
            }

            if (Inventory.instance.billes == 1)
            {
                InventoryUI.instance.UpdateUI("Billes");
            }

            if (Inventory.instance.coulis == 1)
            {
                InventoryUI.instance.UpdateUI("Coulis");
            }

        



    }


    public void SaveData()
    {

            PlayerPrefs.SetInt("coins", Inventory.instance.coinsCount);
            PlayerPrefs.SetInt("ballons", Inventory.instance.ballonsCount);
            PlayerPrefs.SetInt("fraises", Inventory.instance.fraises);
            PlayerPrefs.SetInt("chantilly", Inventory.instance.chantilly);
            PlayerPrefs.SetInt("billes", Inventory.instance.billes);
            PlayerPrefs.SetInt("coulis", Inventory.instance.coulis);
            PlayerPrefs.SetInt("chocolat", Inventory.instance.chocolat);
            PlayerPrefs.SetInt("oeufs", Inventory.instance.oeufs);
            PlayerPrefs.SetInt("sucre", Inventory.instance.sucre);
            PlayerPrefs.SetInt("farine", Inventory.instance.farine);
            PlayerPrefs.SetInt("beurre", Inventory.instance.beurre);
            PlayerPrefs.SetInt("bougies", Inventory.instance.bougie);
            PlayerPrefs.SetInt("objectPicked", Inventory.instance.objectPicked);
            PlayerPrefs.SetFloat("SliderVolumeLevel", audioSource.volume);
        if (CurrentSceneManager.instance.levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
            {
                PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
            }
            PlayerPrefs.SetFloat("SliderVolumeLevel", audioSource.volume);


    }

}
