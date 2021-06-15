using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
   
    Rigidbody2D rbenemigo;
    Animator animEnemigo;

    float velocidad;
    public bool Caminante;
    public bool caminarDerecha;

    public Transform checkHueco, checkPared,checkSuelo;
    public bool detectarPared, detectarHueco, esSuelo;
    public float detectarRadio;
    public LayerMask queEs;
    void Start()
    {
        velocidad = GetComponent<Enemigo>().velocidad;
        rbenemigo = GetComponent<Rigidbody2D>();
        animEnemigo = GetComponent<Animator>();

    }

   
    void Update()
    {
        detectarHueco = !Physics2D.OverlapCircle(checkHueco.position, detectarRadio, queEs);
        detectarPared = Physics2D.OverlapCircle(checkPared.position, detectarRadio, queEs);
        if (detectarHueco||detectarPared)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        if (Caminante)
        {
            rbenemigo.constraints = RigidbodyConstraints2D.FreezeRotation;
            animEnemigo.SetBool("caminar", true);
            if (!caminarDerecha)
            {
                rbenemigo.velocity = new Vector2(-velocidad * Time.deltaTime, rbenemigo.velocity.y);

            }
            else
            {
                rbenemigo.velocity = new Vector2(velocidad * Time.deltaTime, rbenemigo.velocity.y);
            }
        }
    }
    public void Flip()
    {
        caminarDerecha = !caminarDerecha;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}
