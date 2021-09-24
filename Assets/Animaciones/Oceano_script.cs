using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oceano_script : MonoBehaviour
{

    Rigidbody2D rb;
    float limiteCaminataIzquierda;
    float limiteCaminataDerecho;
   

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        limiteCaminataDerecho = transform.position.x + GetComponent<CircleCollider2D>().radius;
        limiteCaminataIzquierda = transform.position.x - GetComponent<CircleCollider2D>().radius;
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(40, rb.velocity.y);

        if (transform.position.x < limiteCaminataIzquierda) transform.localScale = new Vector3(2, 2, 2);

        if (transform.position.x > limiteCaminataDerecho) transform.localScale = new Vector3(-2, 2, 2);

    }
}

  



