using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subarma : MonoBehaviour
{
    public GameObject arma_destello;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        usardestello();
    }
    
    public void usardestello()
    {
        if (Input.GetKey("e"))
        {
            GameObject subArma = Instantiate(arma_destello, transform.position, Quaternion.identity);
            subArma.GetComponent<Rigidbody2D>().AddForce(new Vector2(600f, 0f), ForceMode2D.Force);
        }
    }
}

