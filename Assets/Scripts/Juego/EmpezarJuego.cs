using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

public class EmpezarJuego : MonoBehaviour
{
    
    public GameObject Pergamino;
    public Charactermovement charactermovement;
    public GameObject player;
    public Boolean leeido = false;
    public Follow_Player Follow_Player;
    public EnemyGenerator enemygenerator;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Destroy(Pergamino);
            Debug.Log("La tecla ha sido presionada.");
            charactermovement.PauseMovement();
            leeido = true;
            
            
        }
        if (leeido==true)
        {
            charactermovement.teleportPlayer(player);
            charactermovement.ResumeMovement();
            charactermovement.speed = 5f;
            //enemygenerator.startInvoke = true;
        }
    }
}
