using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamara : MonoBehaviour
{
    public Transform jugador;
    public float xpos;
    public float ypos;
    public float zpos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(jugador.position.x + xpos, jugador.position.y + ypos, zpos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(jugador.position.x + xpos, jugador.position.y + ypos, zpos);
    }
}
