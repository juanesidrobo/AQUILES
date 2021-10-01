using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaOceano : MonoBehaviour
{
    float velocidadMovimiento;
    Rigidbody2D rb2d;
    Vector2 moveDirection;
    Aquiles target;
    // Start is called before the first frame update
    void Start()
    {
        velocidadMovimiento = GetComponent<Enemigo>().velocidad;
        rb2d = GetComponent<Rigidbody2D>();
        target = Aquiles.instance;

        moveDirection = (target.transform.position - transform.position).normalized * velocidadMovimiento;
        rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
