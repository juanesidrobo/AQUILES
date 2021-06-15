using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Zeus;

    void Update()
    {
        if (Zeus != null)
        {
            Vector3 position = transform.position;
            position.x = Zeus.transform.position.x;
            transform.position = position;
        }
         
    }
}