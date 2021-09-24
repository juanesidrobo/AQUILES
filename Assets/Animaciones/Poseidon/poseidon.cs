using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class poseidon : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    bool enPiso;
    public Transform refPie;
    float velX = 20f;

    public Transform contenedorArma;
    bool tieneArma;

    public Transform mira;
    public Transform referenciaManoArma;

    public Transform referenciaOjos;
    public Transform cabeza;

    



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //para movernos 
        float movX;
        movX = Input.GetAxis("Horizontal");
        anim.SetFloat("caminar", Mathf.Abs(movX));
        rb.velocity = new Vector2(velX * movX, rb.velocity.y);



        //para saber si esta en el piso 
        enPiso = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 8);
        anim.SetBool("sobrePiso", enPiso);

        //para saltar
        if (Input.GetButtonDown("Vertical") && enPiso)
        {
            rb.AddForce(new Vector2(0, 500),
           ForceMode2D.Impulse);

        }

        // para que gire 
        if (tieneArma)
        {
            if (mira.transform.position.x < transform.position.x) transform.localScale = new Vector3(-1f, 1f, 1f);
            if (mira.transform.position.x > transform.position.x) transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else
        {
            if (movX < 0) transform.localScale = new Vector3(-1f, 1f, 1f);

            if (movX > 0) transform.localScale = new Vector3(1f, 1f, 1f);

        }

        if (tieneArma)
        {

            // detectar el mouse y poner ahi la mira 

            mira.position = Camera.main.ScreenToWorldPoint
                (new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                -Camera.main.transform.position.z
                ));

            referenciaManoArma.position = mira.position;

            if (Input.GetButtonDown("Fire1")) disparar();

        }

     

    }

    private void LateUpdate()
    {
        if (tieneArma)
        {
            // que gire la cabeza para mirar al mouse 

            cabeza.up = referenciaOjos.position - mira.position;

            // que el arma tambien mire al mouse

            contenedorArma.up = contenedorArma.position - mira.position;

        }
    }

    void disparar()
    {
        Vector3 direccionDisparo = (mira.position - contenedorArma.position).normalized;

       int  magnitudPateoArma = -1;
        // para que se mueva atras luego de disparar

        rb.AddForce(magnitudPateoArma * -direccionDisparo, ForceMode2D.Impulse);

       // para dispare

        RaycastHit2D hit = Physics2D.Raycast
             (contenedorArma.position,
             direccionDisparo, 1000f, ~(1 << 8));


        if (hit.collider != null)
        {
            //le dio a algo
            if (hit.collider.gameObject.CompareTag("Enemigo"))
            {
                // le da a un enemigo 
                Destroy(hit.collider.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma"))
        {
            tieneArma = true;
            Destroy(collision.gameObject);
            contenedorArma.gameObject.SetActive(true);
        }
    }




}
