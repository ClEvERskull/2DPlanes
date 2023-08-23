using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
    public Canvas pauseMenu;
    public Canvas settings;


    void Awake()
    {
        settings.gameObject.SetActive(false);
    }
    public void loadLevel(string name)
    {
        Application.LoadLevel(name);
        Time.timeScale = 1;
    }

    /*public void QuitApp()
    {
        Application.Quit();
    }*/

    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }

    public void pause()
    {
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void settingsMenu()
    {
        settings.gameObject.SetActive(true);
    }

    public void quitSettingsMenu()
    {
        settings.gameObject.SetActive(false);
    }
}
