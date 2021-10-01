using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AquilesLevel1 : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    bool enPiso;
    public Transform refPie;
    float velX = 20f;
    public Transform referenciaOjos;
    public Transform cabeza;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //para movernos 
        float movX;
        movX = Input.GetAxis("Horizontal");
        anim.SetFloat("caminar", Mathf.Abs(movX));
        rb.velocity = new Vector2(velX * movX, rb.velocity.y);

        if (movX < 0) transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);

        if (movX > 0) transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

        //para saber si esta en el piso 
        enPiso = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 8);
        anim.SetBool("sobrePiso", enPiso);

        //para que se reinicie cuando cae 
        if (transform.position.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetButtonDown("Vertical") && enPiso)
        {
            rb.AddForce(new Vector2(0, 700),
           ForceMode2D.Impulse);

        }
    }
}
