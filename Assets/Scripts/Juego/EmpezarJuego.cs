using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EmpezarJuego : MonoBehaviour
{
    public GameObject Pergamino;
    public GameObject Victoria;
    public Charactermovement charactermovement;
    public GameObject player;
    private Boolean leeido = false;
    
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
            leeido = true;
            
        }
        if (leeido==true)
        {
            charactermovement.teleportPlayer(player);
            charactermovement.PauseMovement();
        }
    }
}
