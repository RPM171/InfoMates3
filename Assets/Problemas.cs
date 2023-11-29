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
    public TextMeshProUGUI resultadoText;
    public Text inputFieldResultatEscrit;

    // Start is called before the first frame update
    void Start()
    {
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
        
        primero = "Pocion de curacion: Para crear una poción de curación, necesitas mezclar partes de hígado de cerdo,corazón de pollo, pico de cuervo y uña de caballo.Si el hígado de cerdo pesa " + parametros[0] + " gramos, el corazón de pollo pesa " + parametros[1] + "  gramos, el pico de cuervo con " + parametros[2] + " gramos y uña de caballo que pesa " + parametros[3] + " ¿cuántos gramos pesara la pocion?";
        segundo = "Poción de fuerza: Para crear una poción de fuerza, necesitas mezclar partes iguales de cuernos de toro, colmillos de jabalí, aleta de tiburon y una anguila. Si los cuernos de toro pesan " + parametros[0] + " gramos y los colmillos de jabalí pesan " + parametros[1] + " gramos, los gramos de aleta de tiburon pesa " + parametros[2] + " y una anguila de " + parametros[3] + " ¿cuántos gramos pesara la pocion?";
        listaProblemas[0] = primero;
        listaProblemas[1] = segundo;
        texto.text = listaProblemas[randomProblema];


    }

    public void LeerResultado()
    {
        string inputUsuariString = Regex.Replace(resultadoText.text, "<.*?>", string.Empty);


        Debug.Log("-------" + resultadoString.Equals(resultadoString) + "inputUsuariString=" + inputUsuariString);

        /*int inputUsuari = 0;
        inputUsuari += int.Parse(inputUsuariString);*/

        Debug.Log(inputUsuariString);

        bool iguals = (inputUsuariString == resultadoString);
        Debug.Log("iguals=" + iguals);

        // Debug.Log(resultadoText.text + " - " + resultadoString);
        if (iguals)
        {
            Debug.Log("Bien");
        }
        else
        {
            Debug.Log("Mal");
        }

        /*if (int.TryParse(resultadoText.text, out inputUsuari)){
        
            Debug.Log("Es integer"); 
            if (inputUsuari==resultado)
            {
                Debug.Log("Bien");
            }
            else
            {
                Debug.Log("Mal");
            }

        }
        else
        {
            Debug.Log("No es integer");
        }
       */
        
    }
}



