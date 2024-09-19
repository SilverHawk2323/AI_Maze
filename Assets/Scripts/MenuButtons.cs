using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject mainMenu;



    public void Restart()
    {
        SceneManager.LoadScene("Maze");
    }

    public void Controls()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Return()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.gm.pauseGame = false;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
