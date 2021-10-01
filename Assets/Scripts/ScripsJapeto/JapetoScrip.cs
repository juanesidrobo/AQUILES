using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JapetoScrip : MonoBehaviour
{
    Rigidbody2D Rb2D;
    public Animator animator;
    public float runSpeed = 8f;
    public float jumpSpeed = 30;
    public bool betterJump = false;
    public float fallMultiplier = 10f;
    public float lowJumpMultiplier = 12f;
    public GameObject crossed1Prefab;
    public float attackSpeed = 1f;
    bool attacking;
    //Variables relacionadas con la vida
    //Puntos de vida
    public int maxHealthPoints = 15;
    //Vida actual
    public int healthpoints;


    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>();
        healthpoints = maxHealthPoints;
    }


    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            Rb2D.velocity = new Vector2(runSpeed, Rb2D.velocity.y);
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            Rb2D.velocity = new Vector2(-runSpeed, Rb2D.velocity.y);
            transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
            animator.SetBool("Run", true);
        }
        else

        {
            Rb2D.velocity = new Vector2(0, Rb2D.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("w") && CheckGround.isGrounded)
        {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, jumpSpeed);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }

        if (betterJump)
        {
            if (Rb2D.velocity.y < 0)
            {
                Rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (Rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                Rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }

        //para que se reinicie cuando cae 
        if (transform.position.y < -19)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator Attack(float seconds)
    {
        attacking = true; //Activar Bandera
        //Si hay objetivo y el prefab es correcto crear instancia
        if (crossed1Prefab != null)
        {
            Instantiate(crossed1Prefab, transform.position, transform.rotation);
            //Esperar los segundos de turno antes de hacer otro ataque
            yield return new WaitForSeconds(seconds);
        }
        attacking = false; //Desactivar bandera
    }

    //Gestión de ataque (hecha en 1 sola para ahorrar linea, permite disminuir y destruir)
    public void Attacked1()
    {
        healthpoints = healthpoints - 1;
        if (healthpoints <= 0)
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.muerteEnemigo);
            SendMessage("Change");
            Destroy(gameObject);
        }
    }

}