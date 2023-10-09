using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EstatGameManager _estatGameManager;
    public GameObject Menu;
    public GameObject KevinMenu;
    public GameObject Canvas;
    public enum EstatGameManager
    {
        Inici,
        Jugant,
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
                Menu.SetActive(false);
                KevinMenu.SetActive(false);
                Canvas.SetActive(false);
                break;
            case EstatGameManager.Pausa:
               
                break;
            case EstatGameManager.Inventario:

                break;
            case EstatGameManager.GameOver:
                
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
}
