using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poseidon : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb;
    bool enPiso;
    public Transform refPie;
    float velX = 10f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        float movX;
        movX = Input.GetAxis("Horizontal");
        anim.SetFloat("caminar", Mathf.Abs(movX));
        rb.velocity = new Vector2(velX * movX, rb.velocity.y);


        enPiso = Physics2D.OverlapCircle(refPie.position, 1f, 1 << 7);
        anim.SetBool("sobrePiso", enPiso);

        if (Input.GetButtonDown("Vertical") && enPiso)
        {
            rb.AddForce(new Vector2(0, 500),
           ForceMode2D.Impulse);
        }

        if (movX < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (movX > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }
}
