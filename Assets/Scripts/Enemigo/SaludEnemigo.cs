using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{
    Enemigo enemigo;
    public bool esGolpeado;
    private void Start()
    {
        enemigo = GetComponent<Enemigo>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma")&& esGolpeado)
        {
            enemigo.puntosSalud -= 2f;
            StartCoroutine(Golpeado());
            if (enemigo.puntosSalud <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Golpeado()
    {
        esGolpeado = true;

        yield return new WaitForSeconds(0.5f);
        esGolpeado = false;
    }
}
