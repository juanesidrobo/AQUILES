using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTartaro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Change());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Peticion");
    }
}
