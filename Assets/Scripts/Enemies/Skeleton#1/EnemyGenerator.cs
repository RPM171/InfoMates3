using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject enemigoPrefab;
    public float tiempoEntreEnemigos;
    public int totalEnemigos; // N�mero total de enemigos a generar
    public float X;
    public float y;

    private int enemigosGenerados = 0;
    private float tiempoUltimaGeneracion;
    void Start()
    {
        tiempoUltimaGeneracion = Time.time;
        InvokeRepeating("GenerarEnemigo", 5f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        GenerarEnemigo();
    }
    void GenerarEnemigo()
    {
        if (enemigosGenerados < totalEnemigos && Time.time - tiempoUltimaGeneracion > tiempoEntreEnemigos)
        {
            Vector2 posicion = new Vector2(X, y);
            Instantiate(enemigoPrefab, posicion, Quaternion.identity);
            enemigosGenerados++;
            tiempoUltimaGeneracion = Time.time;
           // enemigoPrefab.SetActive(true);
            
        }
        else
        {
            // Si ya se generaron todos los enemigos, cancela la invocaci�n repetida
            CancelInvoke("GenerarEnemigo");
        }
    }
}
