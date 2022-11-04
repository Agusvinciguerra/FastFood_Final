using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceRata : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        InvokeRepeating("Aparece", 1, 3f);
    }



    public void Aparece()
    {
        anim.SetTrigger("Rata");
    }
}
