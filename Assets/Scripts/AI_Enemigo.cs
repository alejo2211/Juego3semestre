using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Enemigo : MonoBehaviour
{
    
    
    public Transform target;
    public NavMeshAgent agente;
    public int daño;
    public Animator animator;
    public bool inIdle;
  
    private void Start()
    {
        target = PlayerController.singleton.transform;
        

    }
    
    
    void Update()
    {
        StartCoroutine(Idle());
        agente.SetDestination(target.position);
       
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bala"))
        {
            GameManager.singleton.ContadorEnemigos();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        
    }
    
    IEnumerator Idle()
    {
        yield return new WaitForSeconds(3);
        if (inIdle == true)
        {
           
            animator.SetBool("inidle",true);
        }

    }
}
