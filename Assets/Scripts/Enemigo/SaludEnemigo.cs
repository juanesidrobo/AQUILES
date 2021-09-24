using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaludEnemigo : MonoBehaviour
{
    public GameObject ganoAquiles;
    Enemigo enemigo;
    bool esGolpeado;
    private void Awake()
    {
        ganoAquiles.SetActive(false);
    }
    private void Start()
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
            enemigo.puntosSalud -= 2f;
            AudioManager.instance.PlayAudio(AudioManager.instance.golpear);
            StartCoroutine(Golpeado());
            if (enemigo.puntosSalud <= 0)
            {
                MorirEnemigo();
                AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
                StartCoroutine(EsperarEscena());
                Victoria();
                AudioManager.instance.PlayAudio(AudioManager.instance.ganar);
                StartCoroutine(EsperarEscena());
                CambiarEscena();
            }
        }
    }
    IEnumerator Golpeado()
    {
        esGolpeado = true;

        yield return new WaitForSeconds(0.5f);
        esGolpeado = false;
    }
    public void MorirEnemigo()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
        Destroy(gameObject);
    }
    public void Victoria()
    {
        ganoAquiles.SetActive(true);
    }
    IEnumerator EsperarEscena()
    {
        yield return new WaitForSeconds(10f);
    }
    public void CambiarEscena()
    {
        SceneManager.LoadScene("Level2");
    }
}
