using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBotones : MonoBehaviour
{
    public GameObject jugar;
    public GameObject jugarGrande;
    public GameObject Puntuciones;
    public GameObject PuntuacionesGrande;
    public GameObject Salir;
    public GameObject SalirGrande;
    public GameObject Titulo;
    public GameObject TituloGrande;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JugarG()
    {
        jugar.SetActive(false);
        jugarGrande.SetActive(true);
    }
    public void JugarP()
    {
        jugar.SetActive(true);  
        jugarGrande.SetActive(false);
    }
    public void puntuaG()
    {
        PuntuacionesGrande.SetActive(true);
        Puntuciones.SetActive(false);
    }
    public void puntuaP()
    {
        PuntuacionesGrande.SetActive(false);
        Puntuciones.SetActive(true);
    }
    public void salirG()
    {
        SalirGrande.SetActive(true);
        Salir.SetActive(false);
    }
    public void salirP()
    {
        SalirGrande.SetActive(false);
        Salir.SetActive(true);
    }
    public void TituloG() { 
        Titulo.SetActive(false);
        TituloGrande.SetActive(true);
    }
    public void TituloP()
    {
        Titulo.SetActive(true);
        TituloGrande.SetActive(false);
    }
}
