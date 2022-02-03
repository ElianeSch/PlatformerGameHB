using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{

    public static CurrentSceneManager instance;
    public int levelToUnlock;
    public Vector3 respawnPoint;
    public int objectsToPick;
    public bool respawn;
    public bool DontDestroyMusic;
    public bool isUndertale = false;
    public bool isEnd = false;
    private void Awake()
    {
        if(instance !=null)
        {
            Debug.LogWarning("Plus d'une instance de current scene manager");
            return;
        }
        instance = this;

        if (respawn)
        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }



}
