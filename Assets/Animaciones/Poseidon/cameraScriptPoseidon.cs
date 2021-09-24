using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScriptPoseidon : MonoBehaviour
{
    public GameObject Poseidon;


    void Update()
    {
        Vector3 position = transform.position;
        position.x = Poseidon.transform.position.x;
        transform.position = position;


    }
}
