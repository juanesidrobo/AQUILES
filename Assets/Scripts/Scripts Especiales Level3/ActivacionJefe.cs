using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionJefe : MonoBehaviour
{
    public GameObject OceanoAparece;

    private void Start()
    {
        OceanoAparece.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            JefePanel.instanciar.JefeActivador();
            StartCoroutine(EsperarJefe());
            
        }
    }
    IEnumerator EsperarJefe()
    {
        var velocidadActual = Aquiles.instance.velX;
        Aquiles.instance.velX = 0;
        OceanoAparece.SetActive(true);
        yield return new WaitForSeconds(3.1f);
        Aquiles.instance.velX = velocidadActual;
        Destroy(gameObject);
    }
}
