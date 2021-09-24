using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAquiles : MonoBehaviour
{
    bool haLanzado;
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
        if (Input.GetKeyDown("e"))
        {
            if (!haLanzado)
            {
                GameObject subArma = Instantiate(arma_destello, transform.position, Quaternion.Euler(0, 0, 0));
                if (transform.localScale.x < 0)
                {
                    subArma.GetComponent<Rigidbody2D>().AddForce(new Vector2(-600f, 0f), ForceMode2D.Force);
                }
                else
                {
                    subArma.GetComponent<Rigidbody2D>().AddForce(new Vector2(600f, 0f), ForceMode2D.Force);
                }
                StartCoroutine(Lanzar());
            }
        } 
    }
    IEnumerator Lanzar()
    {
        haLanzado = true;
        yield return new WaitForSeconds(2.3f);
        haLanzado = false;
    }
}
