using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectarjugador : MonoBehaviour
{
   private void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && transform.GetComponentInParent<Proyectilenemigo>().vigilante==true)
        {
            transform.GetComponentInParent<Proyectilenemigo>().Disparar();
        }
    }
}
