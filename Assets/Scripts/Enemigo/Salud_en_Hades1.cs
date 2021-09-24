using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Salud_en_Hades1 : MonoBehaviour
{
    
    Enemigo enemigo;
    bool esGolpeado;
    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponent<Enemigo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma") && !esGolpeado)
        {
            enemigo.puntosSalud -= 2f;
            
            StartCoroutine(Golpeado());
            if (enemigo.puntosSalud <= 0)
            {
                MorirEnemigo();
                CambiarEscena();
            }
        }
    }
    IEnumerator Golpeado()
    {
        esGolpeado = true;

        yield return new WaitForSeconds(0.5f);
        esGolpeado = false;
    }
    public void MorirEnemigo()
    {
        
        Destroy(gameObject);
    }
    public void CambiarEscena()
    {
        SceneManager.LoadScene("EscenaJapeto");
    }
}
