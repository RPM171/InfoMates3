using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarJuego : MonoBehaviour
{
    public GameObject Pergamin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pergamin.SetActive(false);
            Debug.Log("La tecla Espacio ha sido presionada.");
            Destroy(Pergamin);
            
        }
    }
}
