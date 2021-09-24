using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojoproyectil : MonoBehaviour
{
    public GameObject proyectil;
    public float tiempoaDisparar;
    public float dispararAbajo;
    bool tomado;

    public bool frecuenciaDisparo;
    public bool vigilante;
    void Start()
    {
        dispararAbajo = tiempoaDisparar;
    }
    void Update()
    {
        if (frecuenciaDisparo)
        {
            dispararAbajo -= Time.deltaTime;
            if (dispararAbajo < 0)
            {
                Disparar();
            }
        }
        if (vigilante)
        {

        }
    }
    public void Disparar()
    {
        
            GameObject circle = Instantiate(proyectil, transform.position, Quaternion.identity);
            if (transform.localScale.x < 0)
            {
                circle.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0), ForceMode2D.Force);
            }
            else
            {
                circle.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0), ForceMode2D.Force);
            }
            dispararAbajo = tiempoaDisparar;
        
    }

    
}
