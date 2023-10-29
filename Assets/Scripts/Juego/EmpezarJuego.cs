using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarJuego : MonoBehaviour
{
    public GameObject Pergamino;
    public GameObject Victoria;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pergamino.SetActive(false);
            Debug.Log("La tecla Espacio ha sido presionada.");
            Destroy(Pergamino);
            Victoria.SetActive(true); 
            
        }
    }
}
