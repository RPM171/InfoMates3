using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void EscenaJugar()
    {
        SceneManager.LoadScene("lvl1");
        Time.timeScale = 1;
    }
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ScenaMates()
    {
        SceneManager.LoadScene("Mates");
    }
    public void LvlBoss()
    {
        SceneManager.LoadScene("LikeBoss");
    }
    public void Controles()
    {
        SceneManager.LoadScene("Controls");
    }

}


