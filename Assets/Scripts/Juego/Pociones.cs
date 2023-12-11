using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Pociones : MonoBehaviour
{
    private int Problema;
    private int Solucion;
    [SerializeField] private Charactermovement player;
    [SerializeField] private Player_attack attack;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private GameObject text;
    private float contador;
    // Start is called before the first frame update
    void Start()
    {
        Problema = PlayerPrefs.GetInt("numeroProblemas");
        Solucion = PlayerPrefs.GetInt("Solucionario");
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador.Equals(0))
        {
            BuffPociones();
            Invoke("textoDesaperecer",2);
            contador = 1;
        }
        
    }

    public void textoDesaperecer()
    {
        text.SetActive(false);
    }

    public void BuffPociones()
    {
        if (!SceneManager.GetActiveScene().name.Equals("lvl1") && !SceneManager.GetActiveScene().name.Equals("Mates"))
        {
            if (Solucion == 1)
            {
                switch (Problema)
                {
                    case 0:
                        player.maxHealth += 30;
                        texto.text = "La pocion ha salido exquisita. Has ganado 30 de vida";
                        break;

                    case 1:
                        attack.damage += 10;
                        texto.text = "La pocion ha salid exquisita. Has ganado 10 de daño";
                        break;

                    case 2:
                        player.speed += 1;
                        texto.text = "La pocion ha salid exquisita. Has ganado mas velocidad";
                        break;
                }
            }
            if (Solucion == 0)
            {

                switch (Problema)
                {
                    case 0:
                        player.maxHealth -= 10;
                        texto.text = "Algo ha salido mal. Has perdido 10 de vida";
                        texto.color = Color.red;
                        break;

                    case 1:
                        attack.damage -= 5;
                        texto.text = "Algo ha salido mal. Has perdido 5 de daño";
                        texto.color = Color.red;
                        break;

                    case 2:
                        player.speed -= 1;
                        texto.text = "Algo ha salido mal. Has perdido algo de velocidad";
                        texto.color = Color.red;
                        break;
                }
            }
        }
    }
    IEnumerator desaparecerText(float duracion)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(duracion);
        text.SetActive(false);
    }
}
