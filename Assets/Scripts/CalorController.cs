using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalorController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject canvasGameOver;
    public  GameObject pauseBoton;
    
    void Start()
    {
        canvasGameOver.SetActive(false);
        Time.timeScale = 1;
        pauseBoton.SetActive(true);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("colision");
            canvasGameOver.SetActive(true);
            Time.timeScale = 0f;
            pauseBoton.SetActive(false);
        }
    }
}
