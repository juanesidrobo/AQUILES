using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludEnemigoLvl3 : MonoBehaviour
{
    Enemigo enemigo;
    bool esGolpeado;
    public GameObject efectoMuerte;
    void Start()
    {
        enemigo = GetComponent<Enemigo>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Arma") && !esGolpeado)
        {
            
            enemigo.puntosSalud -= 1f;
            AudioManager.instance.PlayAudio(AudioManager.instance.golpear);
            StartCoroutine(Golpeado());
            if (enemigo.puntosSalud <= 0)
            {
                Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                MorirEnemigo();
                AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
            }
        }
        if (collision.CompareTag("Bala") && !esGolpeado)
        {

            enemigo.puntosSalud -= 4f;
            AudioManager.instance.PlayAudio(AudioManager.instance.golpear);
            StartCoroutine(Golpeado());
            if (enemigo.puntosSalud <= 0)
            {
                Instantiate(efectoMuerte, transform.position, Quaternion.identity);
                MorirEnemigo();
                AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
            }
        }
    }

    IEnumerator Golpeado()
    {
        esGolpeado = true;

        yield return new WaitForSeconds(0.8f);
        esGolpeado = false;
    }
    public void MorirEnemigo()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
        Destroy(gameObject);
    }
    
}
