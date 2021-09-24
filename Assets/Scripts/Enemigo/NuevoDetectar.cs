using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoDetectar : MonoBehaviour
{
    //public bool esGolpeado;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Aquiles")&&transform.GetComponentInParent<Ojoproyectil>().vigilante==true )
        {
            //StartCoroutine(Golpeado());
            transform.GetComponentInParent<Ojoproyectil>().Disparar();
        }
    }
    /*IEnumerator Golpeado()
    {
        esGolpeado = true;

        yield return new WaitForSeconds(0.8f);
        esGolpeado = false;
    }*/
}
