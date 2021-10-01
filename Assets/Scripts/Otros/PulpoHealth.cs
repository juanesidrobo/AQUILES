using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulpoHealth : MonoBehaviour
{
    Rigidbody2D Rb2D;
    public float maxHealthPoints = 15;
    public float healthpoints;
   
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
        healthpoints = maxHealthPoints;
    }

    public void Attacked()
    {
        healthpoints = healthpoints - 1;
        if (healthpoints == 0)
        {
            Destroy(gameObject);
        }
    }
}
