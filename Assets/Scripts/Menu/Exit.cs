using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void Salir()
    {
        // Salir del juego (solo funciona en builds, no en el editor)
        Application.Quit();
    }
}