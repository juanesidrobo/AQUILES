using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyMovement : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public int direccion;
    public float vCaminar;
    public float vCorrer;
    public GameObject target;
    public bool atacando;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.Find("Aquiles");
    }
    
    // Update is called once per frame
    void Update()
    {
        Comportamientos();
        
    }
    public void Comportamientos()
    {
        anim.SetBool("correr", false);
        cronometro += 1*Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
            
        }
        switch (rutina)
        {
            case 0:
                anim.SetBool("caminar", false);
                break;
            case 1:
                direccion = Random.Range(0, 2);
                rutina++;
                break;
            case 2:
                switch (direccion)
                {
                    case 0:
                        
                            transform.rotation = Quaternion.Euler(0, 0, 0);
                            transform.Translate(Vector3.right * vCaminar * Time.deltaTime);
                        
                        
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * vCaminar * Time.deltaTime);
                        break;
                        
                }
                anim.SetBool("caminar", true);
                break;
        }
    }
    
}
