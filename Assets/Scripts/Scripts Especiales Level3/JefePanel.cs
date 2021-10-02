using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JefePanel : MonoBehaviour
{
    public GameObject Paneljefe;
    public GameObject muros;
    public GameObject Mensaje;
    public static JefePanel instanciar;

    private void Awake()
    {
        if (instanciar == null)
        {
            instanciar = this;
        }        
    }
    void Start()
    {
        Paneljefe.SetActive(false);
        muros.SetActive(false);
        Mensaje.SetActive(false);
    }

    public void JefeActivador()
    {
        Paneljefe.SetActive(true);
        muros.SetActive(true);
        Mensaje.SetActive(true);
        StartCoroutine(MostrarMensaje());
    }
    public void JefeDesactivador()
    {
        Paneljefe.SetActive(false);
        muros.SetActive(false);

    }
    IEnumerator MostrarMensaje()
    {
        yield return new WaitForSeconds(2f);
        Destroy(Mensaje);
    }
}
