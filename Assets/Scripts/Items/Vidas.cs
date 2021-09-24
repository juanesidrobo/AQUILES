using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public float saludADar;
    bool tomado;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Aquiles")&&tomado==false)
        {
            collision.GetComponent<AquilesHealth>().salud += saludADar;
            AudioManager.instance.PlayAudio(AudioManager.instance.vida);
            Destroy(gameObject);
            tomado = true;
        }
        
    }
}
