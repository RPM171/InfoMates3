using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField ]private GameObject titulo;
    [SerializeField] private GameObject restart;
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject restartGrande;
    [SerializeField] private GameObject exitGrande;
    [SerializeField] private GameObject pause;
    private bool pausa;
    void Start()
    {
        pausa = false;
    }

    // Update is called once per frame
    void Update()
    {
        PausaOn_Off();
    }
    public void Jugar()
    {
        pause.SetActive(false);
        Time.timeScale = 1.0f;
        pausa = false;
        
    }

    public void RestartGrande()
    {
        restart.SetActive(false);
        restartGrande.SetActive(true);
    }
    public void ExitGrande()
    {
        exit.SetActive(false);
        exitGrande.SetActive(true);
    }
    public void RestarP()
    {
        restart.SetActive(true);
        restartGrande.SetActive(false);
    }
    public void ExitP()
    {
        exit.SetActive(true);
        exitGrande.SetActive(false);
    }

    public void PausaOn_Off()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa == false)
            {
                Time.timeScale = 0f;
                pause.SetActive(true);
                pausa = true;
            }
            else if (pausa == true)
            {
                Jugar();
                pausa = false;
            }
        }
    }
}
