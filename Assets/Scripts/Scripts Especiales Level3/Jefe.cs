using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jefe : MonoBehaviour
{
    public Transform[] transformaciones;
    public GameObject DestinoFinal;

    public float tiempoADisparar, cuentaRegresiva;
    public float tiempoATeleT, cuentaTeleT;

    public float SaludEnemigo, saludActual;
    public Image saludImagen;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = transformaciones[1].position;
        cuentaRegresiva = tiempoADisparar;
        cuentaTeleT=tiempoATeleT;
    }
    private void Update()
    {
        CuentaRegresiva();

        
        DanioJefe();
        EscalaJefe();
    }
    public void CuentaRegresiva()
    {
        cuentaRegresiva -= Time.deltaTime;
        cuentaTeleT -= Time.deltaTime;
        if (cuentaRegresiva < 0)
        {
            DispararJugador();
            cuentaRegresiva = tiempoADisparar;
             
        }
        if (cuentaTeleT <= 0)
        {
            cuentaTeleT = tiempoATeleT;
            Teletransportar();

        }
    }
    public void DispararJugador()
    {
        GameObject spell = Instantiate(DestinoFinal, transform.position, Quaternion.identity);
    } 
    public void Teletransportar()
    {
        var PosicionInicial = Random.Range(0, transformaciones.Length);
        transform.position = transformaciones[PosicionInicial].position;
    }
    // Update is called once per frame
    public void DanioJefe()
    {
        saludActual = GetComponent<Enemigo>().puntosSalud;
        saludImagen.fillAmount = saludActual / SaludEnemigo;
    }
    private void OnDestroy()
    {
        JefePanel.instanciar.JefeDesactivador();
    }
    public void EscalaJefe()
    {
        if (transform.position.x > Aquiles.instance.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
