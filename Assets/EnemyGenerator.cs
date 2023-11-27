using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject enemigoPrefab;
    public float tiempoEntreEnemigos;
    public int totalEnemigos = 5; // N�mero total de enemigos a generar

    private int enemigosGenerados = 0;

    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 5f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        GenerarEnemigo();
    }
    void GenerarEnemigo()
    {
        if (enemigosGenerados < totalEnemigos)
        {
            Vector2 posicion = new Vector2(9.81f, 6.74f);
            Instantiate(enemigoPrefab, posicion, Quaternion.identity);
            enemigosGenerados++;
        }
        else
        {
            // Si ya se generaron todos los enemigos, cancela la invocaci�n repetida
            CancelInvoke("GenerarEnemigo");
        }
    }
}
