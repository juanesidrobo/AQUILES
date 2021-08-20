using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Nivel2 : MonoBehaviour
{
    [Header("Panels")]
    public GameObject backPanel;

    public void OpenPanel(GameObject panel)
    {
        backPanel.SetActive(false);

        panel.SetActive(true);
    }

    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
