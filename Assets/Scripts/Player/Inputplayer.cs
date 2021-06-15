using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputplayer : MonoBehaviour
{

    public float ejeHorizontal;
   // public float ejeVertical;
    public bool atacar;
    public bool hab1;
    public bool hab2;
    public bool inventario;
    public bool interactuar;
    // Start is called before the first frame update
    /*void Start()
    {
       
    }*/
    
    // Update is called once per frame
    void Update()
    {
        atacar = Input.GetButtonDown("Atacar");
        hab1 = Input.GetButtonDown("Hab1");
        hab2 = Input.GetButtonDown("Hab2");
        inventario = Input.GetButtonDown("Inventario");
        interactuar = Input.GetButtonDown("Interactuar");
        //Ejes de movimiento
        ejeHorizontal = Input.GetAxis("Horizontal");
        //ejeVertical= Input.GetAxis("Vertical");
       // Debug.Log("Eje horizontal es: "+ ejeHorizontal +", Eje vertical es: "+ejeVertical);
    }
 
}
