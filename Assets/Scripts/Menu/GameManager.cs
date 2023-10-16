using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EstatGameManager _estatGameManager;
    public GameObject GameOver;
    public GameObject Pergamino;
    public GameObject textPergamino;
    public enum EstatGameManager
    {
        Inici,
        Jugant,
        Historia,
        Pausa,
        Inventario,
        GameOver
    }
   

    void Start()
    {
        _estatGameManager = EstatGameManager.Inici;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ActuallitzaEstatGameManager()
    {
        switch (_estatGameManager)
        {
            case EstatGameManager.Inici:
               
                break;
            case EstatGameManager.Jugant:
                GameOver.SetActive(false);
                Pergamino.SetActive(false);
                textPergamino.SetActive(false);
                break;
            case EstatGameManager.Pausa:
               
                break;
            case EstatGameManager.Historia:
                Pergamino.SetActive(true);
                textPergamino.SetActive(true);
                break;
            case EstatGameManager.Inventario:

                break;
            case EstatGameManager.GameOver:
                GameOver.SetActive(true);
                break;
        }
    }
    public void SetEstatGameManager(EstatGameManager estat)
    {
        _estatGameManager = estat;
        ActuallitzaEstatGameManager();
    }
    public void PassarAEstatPausa()
    {
        _estatGameManager = EstatGameManager.Pausa;
        ActuallitzaEstatGameManager();
    }
    public void PassarAEstatJugant()
    {
        _estatGameManager = EstatGameManager.Jugant;
        ActuallitzaEstatGameManager();
    }
    public void PassarAEstatInventario()
    {
        _estatGameManager = EstatGameManager.Inventario;
        ActuallitzaEstatGameManager();
    }
    public void PassarAEstatGameOver()
    {
        _estatGameManager = EstatGameManager.GameOver;
        ActuallitzaEstatGameManager();
    }
}
