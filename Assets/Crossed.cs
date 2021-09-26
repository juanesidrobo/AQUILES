using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossed : MonoBehaviour
{
    public float Speed;
    GameObject enemy; //Recuparar al objeto jugador
    Rigidbody2D rb2d;  // Recuperar componenete cuerpo rigido 
    Vector3 target, dir; //Vectores para almacenar el objetivo y su dirección

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb2d = GetComponent<Rigidbody2D>();

        // Recuperar posición del jugador y la dirección normalizada 
        if (enemy != null)
        {
            target = enemy.transform.position;
            dir = (target - transform.position).normalized;
        }
        Noenemies(enemy);
    }

    private void FixedUpdate()
    {
        //Si hay un objetivo movemos el prefab hacia su posición
        if (target != Vector3.zero)
        {
            rb2d.MovePosition(transform.position + (dir * Speed) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy") col.SendMessage("Attacked");
        if (col.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    private void Noenemies(GameObject enemy)
    {
        if (enemy == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        //Si se sale de la pantalla borramos el prefab
        Destroy(gameObject);
    }
}
