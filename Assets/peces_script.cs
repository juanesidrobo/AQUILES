using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peces_script : MonoBehaviour
{

    private Rigidbody2D rb;
    public float velocidadPatrulla;

    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        rb.velocity = new Vector2(velocidadPatrulla, rb.velocity.y);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag=="suelo")
        {
            velocidadPatrulla*= -1;
            this.transform.localScale = new Vector2(this.transform.localScale.x*-1, this.transform.localScale.y);
        }
    }

    
   


}
     


 