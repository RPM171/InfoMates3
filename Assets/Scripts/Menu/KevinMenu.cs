using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KevinMenu : MonoBehaviour
{
        public float fuerzaDeSalto = 5f;
        private Rigidbody rb;
        public GameObject jugador;

        void Start()
        {
            rb = jugador.GetComponent<Rigidbody>();
}

void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Saltar();
            }
        }

        void Saltar()
        {
            rb.AddForce(Vector2.up * fuerzaDeSalto); 
        }
    }



