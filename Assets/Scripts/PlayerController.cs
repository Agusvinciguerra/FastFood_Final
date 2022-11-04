using System.Diagnostics;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using Debug = UnityEngine.Debug;



public class PlayerController : MonoBehaviour
{
    private Touch touch;
    [SerializeField] private float velocidadActual = 0;
    [SerializeField] private float velocidadImpulso = 0.03f;
    [SerializeField] private float velocidadMax = 1f;
    private Animator anim;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject canvasVictory;
    [SerializeField] private GameObject botonPausa;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        canvasVictory.SetActive(false);

        botonPausa.SetActive(true);
        Time.timeScale = 1;
    }
    void Update()
    {
        if(Input.touchCount > 0)
        {
            rb.AddForce(transform.forward * velocidadActual, ForceMode.Force);
            touch = Input.GetTouch(0);
            float screenHalf = Screen.width / 2;
            Vector3 movement = Vector2.zero;

            if(touch.phase == TouchPhase.Moved)
            {
                velocidadActual += velocidadImpulso;
                if(velocidadActual > velocidadMax)
                {
                    velocidadActual = velocidadMax;
                }
                
                anim.SetFloat("Walk", velocidadActual);
                
            }

            if(touch.phase == TouchPhase.Ended)
            {
                velocidadActual = 0;
                anim.SetFloat("Walk", velocidadActual);
            } 
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "VictoryPoint")
        {
            canvasVictory.SetActive(true);
            botonPausa.SetActive(false);
            Time.timeScale = 0;
            touch = Input.GetTouch(0);
        }
    }
}
