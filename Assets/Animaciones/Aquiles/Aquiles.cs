using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Aquiles : MonoBehaviour
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

    public GameObject Bala;
    private float ultimoDisparo;
   


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

        //para que se reinicie cuando cae 
        if (transform.position.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //para saltar
        if (Input.GetButtonDown("Vertical") && enPiso)
        {
            rb.AddForce(new Vector2(0, 700),
           ForceMode2D.Impulse);
                    
        }

        // para que gire 
        if (tieneArma)
        {
            if (mira.transform.position.x < transform.position.x) transform.localScale =  new Vector3(-0.8f, 0.8f, 0.8f);
            if (mira.transform.position.x > transform.position.x) transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        }
        else
        {
            if (movX < 0) transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);

            if (movX > 0) transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

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

            //para que dispare si tiene el arma en mano 

            if (Input.GetKey(KeyCode.Space) && Time.time > ultimoDisparo + 0.25f)
            {
                Disparar();
                ultimoDisparo = Time.time;

            }
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
    
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arma"))
        {
            tieneArma = true;
            Destroy(collision.gameObject);
            contenedorArma.gameObject.SetActive(true);
        }
    }

    private void Disparar()
    {
        Vector3  direccion;
        if (transform.localScale.x == 1.0f) direccion = Vector2.left;
        else direccion = Vector3.right;
       GameObject bala = Instantiate(Bala, transform.position + direccion * 0.1f, Quaternion.identity);
        bala.GetComponent<bala_script>().SetDireccion(direccion);
    }

    
}