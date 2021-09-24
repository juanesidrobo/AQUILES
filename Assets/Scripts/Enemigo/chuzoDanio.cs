using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuzoDanio : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
        if (collision.transform.CompareTag("Aquiles"))
        {
            collision.transform.GetComponent<PlayerRespawn>().MorirAquiles();
        }
    }
}
