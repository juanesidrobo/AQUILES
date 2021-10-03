using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Aquileshealthlvl2 : MonoBehaviour
{
    Rigidbody2D Rb2D;
    //Variables relacionadas con la vida
    //Puntos de vida
    public float maxHealthPoints = 25;
    //Vida actual
    public float healthpoints;
    
    //Barra de vida 
    public Image healthimg;

    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        healthpoints = maxHealthPoints;
    }
   
    public void Attacked1()
    {
        healthpoints = healthpoints - 1;
        healthimg.fillAmount = healthpoints / 25;
        AudioManager.instance.PlayAudio(AudioManager.instance.golpear);

        if (healthpoints == 0)
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.gameOver);
            StartCoroutine(WaitingMusic());

        }
    }
 
    IEnumerator WaitingMusic()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}