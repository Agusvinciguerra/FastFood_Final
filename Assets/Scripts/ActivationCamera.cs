using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivationCamera : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public GameObject victoryUI;
    public GameObject botonPausa;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playableDirector.gameObject.SetActive(true);
            playableDirector.Play();
            gameObject.SetActive(false);

            victoryUI.SetActive(true);
            botonPausa.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
