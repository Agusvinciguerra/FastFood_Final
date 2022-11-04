using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool JuegoEnPausa = false;

    public GameObject pauseMenuUI;
    public GameObject boton;
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        JuegoEnPausa = false;
        boton.SetActive(true);
    }

    public void Pausa()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoEnPausa = true;
        boton.SetActive(false);
    }
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Quitando app");
    }                                                
}
