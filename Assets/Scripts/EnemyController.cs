using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private Transform Player;

    [SerializeField] private NavMeshAgent Enemy;

    [SerializeField] private float distancia;
    [SerializeField] private float distanMax;

    [Header("UI Stuffs")]
    [SerializeField] private GameObject canvasGameOver;
    
    //private Animator anim;
    

    void Start()
    {
        distancia = Vector3.Distance(Player.position, transform.position);
        //anim = GetComponent<Animator>();
        canvasGameOver.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        Enemy.SetDestination(Player.transform.position);
    }

    void EnemyFollows()
    {
        if(distancia > distanMax)
        {
            //anim.SetBool("WalkEnemy", true);
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //anim.SetBool("WalkEnemy", false);
            //anim.SetTrigger("EnemyAttack");
            Debug.Log("colision");
            canvasGameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
}
