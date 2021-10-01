using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aquiles_con_hijo : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    bool enPiso;
    public Transform refPie;

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
        //para saber si esta en el piso 
        enPiso = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 8);
        anim.SetBool("sobrePiso", enPiso);


    }
}
