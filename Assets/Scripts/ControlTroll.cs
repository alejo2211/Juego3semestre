using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ControlTroll : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agente;
    public Animator animator;
    public EstadoT estado;
    public float distanciaAtacarTroll;
    public float vidaTroll;
    
    public GameObject particulasGolpe;

    private void Update()
    {
        switch (estado)
        {
            case EstadoT.siguiendo:
                E_Seguir();
                break;
            case EstadoT.atacando:
                E_Atacar();
                break;
            case EstadoT.muerto:
                break;
            default:
                break;
        }
    }

    public void E_Seguir()
    {
        target = PlayerController.singleton.transform;
        agente.SetDestination(target.position);
        Vector3 cambioDistancia;
        cambioDistancia = transform.position - PlayerController.singleton.transform.position;
        if (cambioDistancia.magnitude < distanciaAtacarTroll)
        {
            CambiarEstado(Estado.atacando);
        }


    }
    public void E_Atacar()
    {
        Vector3 diferenciaAtacar;
        transform.LookAt(PlayerController.singleton.transform.position, Vector3.up);
        diferenciaAtacar = transform.position - PlayerController.singleton.transform.position; //dejar de atacar
        if (diferenciaAtacar.magnitude > distanciaAtacarTroll + 0.5f)
        {
            CambiarEstado(Estado.siguiendo);
        }
    }

    public void CambiarEstado(Estado nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case Estado.siguiendo:
                animator.SetBool("AtaqueTroll", false);
                break;
            case Estado.atacando:
                agente.SetDestination(target.position);
                animator.SetBool("AtaqueTroll", true);
                break;
            case Estado.muerto:
                animator.SetBool("AtaqueTroll", false);
                break;
            default:
                break;
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bala"))
        {
            Instantiate(particulasGolpe, other.transform.position, other.transform.rotation);
           
            vidaTroll--;
            if (PowerUps.powerUps.temporadaDañoDoble)
            {
                vidaTroll--;
            }
            Destroy(other.gameObject);
            if (vidaTroll <= 0)
            {
               
                GameManager.singleton.ContadorEnemigos();
                animator.SetTrigger("muerto");
                Destroy(gameObject, 2);
                Destroy(other.gameObject);
                CambiarEstado(Estado.muerto);

            }
        }

    }


}
public enum EstadoT
{
    siguiendo = 0,
    atacando = 1,
    muerto = 2,
}