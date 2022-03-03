using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public GameObject p_menu;
    
    public void Continue()
    {
        p_menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Debug.Log("Alt + f4");
        Application.Quit();
    }

    public void BackMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
