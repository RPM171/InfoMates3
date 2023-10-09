using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaScript : MonoBehaviour


{

    public bool recogida = false;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (!recogida)
        {
            Destroy(gameObject);

             Charactermovement jugador = FindObjectOfType<Charactermovement>();
            if (jugador != null)
            {
                jugador.tieneCarta = true;
                Debug.Log("El jugador tiene la carta");
            }
        }
    }
}
