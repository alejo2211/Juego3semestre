using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI_Enemigo : MonoBehaviour
{
    
    
    public Transform target;
    public NavMeshAgent agente;
    public int daño;
    private void Start()
    {
        target = PlayerController.singleton.transform;
        

    }
    
    
    void Update()
    {

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

    public void Ataque()
    {
        PlayerController.singleton.RecibirDaño(daño);
    }
    
}
