using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScriptAquiles : MonoBehaviour
{

        public GameObject Aquiles;
       

    void Update()
    {
    Vector3 position = transform.position;
    position.x = Aquiles.transform.position.x;
    transform.position = position; 


    }
}
