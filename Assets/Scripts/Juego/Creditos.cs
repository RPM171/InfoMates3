using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject creditos;
    [SerializeField] GameObject player;
    void Update()
    {
        creditos.transform.position = player.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            canvas.SetActive(false);
            creditos.SetActive(true);
          
        }
    }
}
