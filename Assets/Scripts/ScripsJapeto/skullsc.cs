using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skullsc : MonoBehaviour
{
    public float Speed;
    GameObject player; //Recuparar al objeto jugador
    Rigidbody2D rb2d;  // Recuperar componenete cuerpo rigido 
    Vector3 target, dir; //Vectores para almacenar el objetivo y su dirección

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();

        // Recuperar posición del jugador y la dirección normalizada 
        if (player != null)
        {
            target = player.transform.position;
            dir = (target - transform.position).normalized;
        }
    }

    private void FixedUpdate()
    {
        //Si hay un objetivo movemos la bala hacia su posición
        if (target != Vector3.zero)
        {
            rb2d.MovePosition(transform.position + (dir * Speed) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") col.SendMessage("Attacked1");
        if (col.transform.tag == "Player")
        {
            //Si se choca con el jugador o con un ataque se destruye
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        //Si se sale de la pantalla borramos la calavera
        Destroy(gameObject);
    }


}

