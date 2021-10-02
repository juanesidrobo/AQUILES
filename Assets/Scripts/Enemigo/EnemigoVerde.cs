using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVerde : MonoBehaviour
{
    RaycastHit hit;
    public float Distancia;
    public LayerMask LayerM;
    public bool Right;
    public float Speed;
    RaycastHit hit2;
    public Vector3 v3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right* Distancia);
        Gizmos.DrawRay(transform.position+v3, transform.up*-1* Distancia);
    }
    // Update is called once per frame
    void Update()
    {
        if (Right)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        if (Physics2D.Raycast(transform.position,transform.right,Distancia,LayerM))
        {
            Right =! Right;
        }
        if (Physics2D.Raycast(transform.position+v3, transform.up*-1, Distancia, LayerM))
        {
            
        }
        else
        {
            Right = !Right;
        }
    }
}
