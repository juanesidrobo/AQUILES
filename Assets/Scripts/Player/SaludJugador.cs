using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludJugador : MonoBehaviour
{
    public float salud;
    public float maxSalud;
    public Animator animator;
    void Start()
    {
        salud = maxSalud;
    }
    void Update()
    {
        if (salud > maxSalud)
        {
            salud = maxSalud;
        }
    }
    private void OnColliderEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            salud -= collision.GetComponent<Enemigo>().danioQueDa;
            if(salud <= 0)
            {
                animator.Play("morir_hades");
                collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
            }
           
        }
    }
}
