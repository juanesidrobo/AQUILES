using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    bool esPausa;

    void Awake()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        esPausa = false;
    }

    void Update()
    {
        Pause();
    }
    public void AgainMenu(string Menu)
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !esPausa)
        {
            Time.timeScale = 0;
            menuPausa.SetActive(true);
            esPausa = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && esPausa)
        {
            Time.timeScale = 1;
            menuPausa.SetActive(false);
            esPausa = false;
        }
    }
}
