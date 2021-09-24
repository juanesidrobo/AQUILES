using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public int direccion;
    public float vCaminar;
    public float vCorrer;
    public GameObject target;
    public bool atacando;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamientos();

    }
    public void Comportamientos()
    {
        anim.SetBool("correr", false);
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;

        }
        switch (rutina)
        {
            case 0:
                anim.SetBool("caminar", false);
                break;
            case 1:
                direccion = Random.Range(0, 2);
                rutina++;
                break;
            case 2:
                switch (direccion)
                {
                    case 0:

                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * vCaminar * Time.deltaTime);


                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * vCaminar * Time.deltaTime);
                        break;

                }
                anim.SetBool("caminar", true);
                break;
        }
    }

}
/*
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
 */
