using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectilenemigo : MonoBehaviour
{
    public GameObject proyectil;

    public float tiempoaDisparar;
    public float dispararAbajo;
    public bool frecuenciadisparar;
    public bool vigilante;
    // Start is called before the first frame update
    void Start()
    {
        dispararAbajo = tiempoaDisparar;
    }

    // Update is called once per frame
    void Update()
    {
        if (frecuenciadisparar)
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
        GameObject ataque_ojo_0 = Instantiate(proyectil, transform.position, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            ataque_ojo_0.GetComponent<Rigidbody2D>().AddForce(new Vector2(400f, 0f), ForceMode2D.Force);
        }
        else
        {
            ataque_ojo_0.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400f, 0f), ForceMode2D.Force);
        }
        dispararAbajo = tiempoaDisparar;
    }
}
