using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject collider;

    private bool isActive;

    


    void Start()
    {
        particles.SetActive(true);
        collider.SetActive(true);
    }

    void Update()
    {
        if(isActive == true)
        {
            StartCoroutine(Desactivation());
        }
        else if (isActive == false)
        {
            StartCoroutine(Activation());
        }
    }

    IEnumerator Activation()
    {
        yield return new WaitForSeconds(5f);
        collider.SetActive(true);
        isActive = true;

        particles.SetActive(true);  
    }

    IEnumerator Desactivation()
    {
        yield return new WaitForSeconds(5f); 
        collider.SetActive(false);
        isActive = false;
        
        particles.SetActive(false); 
    }
}
