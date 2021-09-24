using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peaks : MonoBehaviour
{
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") col.SendMessage("Attacked1");
    }
}
