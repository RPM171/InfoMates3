using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class controlador : MonoBehaviour
{

    public GameObject personaje;
    private Vector3 posicionRelativa;

    // Use this for initialization
    void Start()
    {
        posicionRelativa = transform.position - personaje.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = personaje.transform.position + posicionRelativa;

    }
    void quitarBlockeo()
    {
        transform.position = new Vector3(-18.52f, 6.61f, -10f);
    }
}


