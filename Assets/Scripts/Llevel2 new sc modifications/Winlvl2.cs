using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winlvl2 : MonoBehaviour
{
    public GameObject WinnerAquiles;
    void Awake()
    {
        WinnerAquiles.SetActive(false);
    }

    public void Change()
    {
            StartCoroutine(EsperarEscena());
            WinnerAquiles.SetActive(true);
            AudioManager.instance.PlayAudio(AudioManager.instance.ganar);
            StartCoroutine(Esperarcambio());
            SceneManager.LoadScene("Level3");
    }

    IEnumerator EsperarEscena()
    {
        yield return new WaitForSeconds(10f);
    }

    IEnumerator Esperarcambio()
    {
        yield return new WaitForSeconds(7f);
    }

}
