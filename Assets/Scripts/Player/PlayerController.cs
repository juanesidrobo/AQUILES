using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Atributos))]
public class PlayerController : MonoBehaviour
{
    private Inputplayer inputjugador;
    private Transform trasnformadora;
    private Atributos atributosjugador;

    private Animator animator;
   
    public float horizonte;
    public float down;
    
    public float jumpSpeed = 4;
    private Rigidbody2D miRigidbody2D;
    private bool caminar;
    private SpriteRenderer miSprite;
    int correrHashCode;
    // Start is called before the first frame update
    void Start()
    {
        inputjugador = GetComponent<Inputplayer>();
        trasnformadora = GetComponent<Transform>();
        miRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        atributosjugador = GetComponent<Atributos>();
        correrHashCode = Animator.StringToHash("Caminando");
       
        
       // miSprite = GetComponenet<SpriteRenderer>();
    }
    //Gamelogic
    void Update()
    {
        horizonte = inputjugador.ejeHorizontal;
        //down = inputjugador.ejeVertical;
        caminar = (horizonte > 0);
       if (horizonte !=0 || down != 0)
        {
            SetXYAnimator();
            animator.SetBool(correrHashCode, true);
        }
       else
        {
            animator.SetBool(correrHashCode, false);
        }
        
    }
    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizonte);
        animator.SetFloat("Y", down);
    }

    public void Ataca()
    {
        if (Input.GetKey("q"))
        {
            animator.SetBool("atacar", true);
        }
        else
        {
            animator.SetBool("atacar", false);
        }

    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {

        //Vector2 nuevaPos = trasnformadora.position + new Vector3(velocidad * horizonte*Time.deltaTime, velocidad * down * Time.deltaTime, 0);
        //trasnformadora.position = nuevaPos;
        //Movimiento--
        Ataca();
        miRigidbody2D.velocity = new Vector2(horizonte, down) * atributosjugador.velocidad;
        if (Input.GetKey("w") && salto.estaSuelo)
        {
            SetXYAnimator();
        
            miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, jumpSpeed) * atributosjugador.velocidad;
        }
       
        //miRigidbody2D.AddForce(fuerza);
      
        
    }
    
}
