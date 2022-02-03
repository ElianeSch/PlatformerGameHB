using UnityEngine;

public class Inventory : MonoBehaviour
{

    public int ballonsCount; // compteur de ballons
    public int coinsCount;
    public int objectPicked = 0;
    public int fraises = 0;
    public int chantilly = 0;
    public int billes = 0;
    public int coulis = 0;

    public int chocolat = 0;
    public int oeufs = 0;
    public int beurre = 0;
    public int farine = 0;
    public int sucre = 0;
    public int bougie = 0;


    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    public void AddBalloons(int count)
    {
        ballonsCount += count;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
    }
}
