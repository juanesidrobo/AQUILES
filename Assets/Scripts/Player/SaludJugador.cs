using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaludJugador : MonoBehaviour
{
     
    public float salud;
    public float maxSalud;
    bool esInmune;
    public float tiempoInmune;
    public float fuerzagolpex;
    public float fuerzagolpey;
    Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        salud = maxSalud;
    }
    void Update()
    {
        if (salud > maxSalud)
        {
            salud = maxSalud;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemigo") && !esInmune)
        {
            salud -= collision.GetComponent<Enemigo>().danioQueDa;
            StartCoroutine(inmune());
            if (collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-fuerzagolpex, fuerzagolpey), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-fuerzagolpex, fuerzagolpey), ForceMode2D.Force);
            }
            if(salud <= 0)
            {
                print("Moriste");
                animator.Play("morir_hades");
                StartCoroutine(Esperarmusica());
                AudioManager.instance.PlayAudio(AudioManager.instance.gameOver);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                
            }
           
        }
    }
    IEnumerator inmune()
    {
        esInmune = true;
        yield return new WaitForSeconds(tiempoInmune);
        esInmune = false;
    }
    IEnumerator Esperarmusica()
    {
        yield return new WaitForSeconds(3f);
    }
}
