using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Problemas : MonoBehaviour
{
    private string primero, segundo, resultadoString;
    private string[] listaProblemas = new string[2];
    private int[] parametros = new int[4];
    private int randomProblema;
    private int resultado;
    public TextMeshProUGUI texto;
    public InputField inputField;
    private string escena;
    private int numeroProblema;
    private int solucionario;
    // Start is called before the first frame update
    void Start()
    {
       escena = PlayerPrefs.GetString("NombreEscenaActual");
        texto.text = "Hola2";
       randomProblema = Random.Range(0, 2);
       parametros[0] = Random.Range(0, 501); ; parametros[1] = Random.Range(0, 501) ; parametros[2] = Random.Range(0, 501); parametros[3] = Random.Range(0, 501);
        resultado = parametros[0] + parametros[1] + parametros[2] + parametros[3];
        resultadoString = resultado.ToString();
        Debug.Log(resultadoString);
    }

    // Update is called once per frame
    void Update()
    {
        
        primero = "Pocion de vida: Para crear una poción de vida, necesitas mezclar partes de hígado de cerdo,corazón de pollo, pico de cuervo y uña de caballo.Si el hígado de cerdo pesa " + parametros[0] + " gramos, el corazón de pollo pesa " + parametros[1] + "  gramos, el pico de cuervo con " + parametros[2] + " gramos y uña de caballo que pesa " + parametros[3] + " ¿cuántos gramos pesara la pocion?";
        segundo = "Poción de fuerza: Para crear una poción de fuerza, necesitas mezclar partes iguales de cuernos de toro, colmillos de jabalí, aleta de tiburon y una anguila. Si los cuernos de toro pesan " + parametros[0] + " gramos y los colmillos de jabalí pesan " + parametros[1] + " gramos, los gramos de aleta de tiburon pesa " + parametros[2] + " y una anguila de " + parametros[3] + " ¿cuántos gramos pesara la pocion?";
        listaProblemas[0] = primero;
        listaProblemas[1] = segundo;
        texto.text = listaProblemas[randomProblema];
        PlayerPrefs.SetInt("numeroProblemas", randomProblema);
        PlayerPrefs.SetInt("Solucionario",solucionario);


    }

    public void LeerResultado()
    {
        
        if (inputField.text.Trim().Equals(resultadoString))
        {
            if (escena.Equals("lvl1"))
            {
            Debug.Log("Bien");
            GameObject.Find("SceneManager").GetComponent<Scenes>().lvl2();
                solucionario = 1;
            
            }if (escena.Equals("lvl2"))
            {
                GameObject.Find("SceneManager").GetComponent<Scenes>().LvlBoss();
                solucionario = 1;
            }
            
        }
        else
        {
            Debug.Log("Mal");
            solucionario = 0;
        }        
    }
}



