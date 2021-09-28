using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjetos : MonoBehaviour
{
    public Transform puntoA, puntoB;
    public float velocidad;
    public bool puedeMoverse;
    public bool puedeEsperar;
    public bool seraDestruida;
    public float DestruirCD;
    bool moverA;
    bool moverB;

    private void Start()
    {
        moverA = true;
        moverB = false;
    }
    private void Update()
    {
        if (puedeMoverse)
        {
            MovimientoObjeto(); 
        }   
    }
    private void MovimientoObjeto()
    {
        float distanceA = Vector2.Distance(transform.position, puntoA.position);
        float distanceB = Vector2.Distance(transform.position, puntoB.position);

        if (distanceA > 0.1f && moverA)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntoA.position, velocidad * Time.deltaTime);
            if (distanceA < 0.3f)
            {
                moverA = false;
                moverB = true;
            }

        }

        if (distanceB > 0.1f && moverB)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntoB.position, velocidad * Time.deltaTime);
            if (distanceB < 0.3f)
            {
                moverA = true;
                moverB = false;
            }

        }
    }
}
