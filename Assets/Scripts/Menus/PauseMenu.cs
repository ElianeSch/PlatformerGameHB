
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject settingsWindow;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            print("AYAAAAAAAAAA");
            if (isPaused)
            {
                Resume();
            }
                
            else
            {
                Paused();

            }
                
        }

    }

    public void Paused()
    {

        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        PlayerMovement.instance.enabled = false;
    }
    public void Resume()
    {
        print("RESUME");
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        PlayerMovement.instance.enabled = true;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettings()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }

}
