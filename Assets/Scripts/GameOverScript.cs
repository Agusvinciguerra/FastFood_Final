using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject GameOverMenuUI;
    public GameObject pauseBoton;
    

    void Update()
    {
        pauseBoton.SetActive(false);
    }

    public void Resume()
    {
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        //JuegoEnPausa = false;
    }

    // void Pausa()
    // {
    //     pauseMenuUI.SetActive(true);
    //     Time.timeScale = 0f;
    //     JuegoEnPausa = true;
    // }

    public void CargarEscena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Quitando app");
    }
}
