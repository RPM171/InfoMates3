using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EmpezarJuego : MonoBehaviour
{
    public GameObject Pergamino;
    public GameObject Victoria;
    public Charactermovement charactermovement;
    
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
            charactermovement.speed = 5f;
            charactermovement.teleportPlayer();
        }
    }
}
