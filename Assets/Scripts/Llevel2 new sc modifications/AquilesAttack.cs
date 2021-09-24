using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AquilesAttack : MonoBehaviour
{
    Rigidbody2D Rb2D;
    public GameObject crossed1Prefab;
    public GameObject crossedspecialPrefab;
    public float attackSpeed = 1f;
    bool attacking;
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }
        else
        {
            if (Input.GetKey(KeyCode.Q))
            {
                if (!attacking) StartCoroutine(Attack2(attackSpeed));
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
        IEnumerator Attack2(float seconds)
        {
            attacking = true; //Activar Bandera
                              //Si hay objetivo y el prefab es correcto crear instancia
            if (crossedspecialPrefab != null)
            {
                Instantiate(crossedspecialPrefab, transform.position, transform.rotation);
                //Esperar los segundos de turno antes de hacer otro ataque
                yield return new WaitForSeconds(seconds);
            }
            attacking = false; //Desactivar bandera
        }


    }
}
