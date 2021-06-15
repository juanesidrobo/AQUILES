using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salto : MonoBehaviour
{
    public static bool estaSuelo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        estaSuelo = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        estaSuelo = false;
    }
}
