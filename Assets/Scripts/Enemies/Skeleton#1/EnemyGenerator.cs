using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject enemigoPrefab;
    public float tiempoEntreEnemigos;
    public int totalEnemigos; // Número total de enemigos a generar
    public float X;
    public float y;
    public EmpezarJuego empezar;
    public bool startInvoke = false;

    private int enemigosGenerados = 0;
    private float tiempoUltimaGeneracion;
    void Start()
    {
        tiempoUltimaGeneracion = Time.time;
        empezar = GetComponent<EmpezarJuego>();
        InvokeRepeating("GenerarEnemigo", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startInvoke == true)
        {
            GenerarEnemigo();
        }
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
            // Si ya se generaron todos los enemigos, cancela la invocación repetida
            CancelInvoke("GenerarEnemigo");
        }
    }
}
