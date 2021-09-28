using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala_script : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    public float velocidad;
    private Vector2 Direction;
   

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Direction * velocidad;
    }

    public void SetDirection (Vector2 direction)
    {
        Direction = direction;
    }


}
