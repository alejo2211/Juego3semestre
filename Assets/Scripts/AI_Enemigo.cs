using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class AI_Enemigo : MonoBehaviour
{
    
    
    public Transform target;
    public NavMeshAgent agente;
    public int da�o;
    public Animator animator;
    public bool inIdle;
    public Estado estado;
    public float distanciaAtacar;

    public float vidaEnemigo;
    public AudioSource muerteOrcoAudio;
    public AudioSource audioHit;
    public GameObject particulasGolpe;
    public Collider col;
    public Rigidbody rb;
    private void Start()
    {

    }
    
    
    void Update()
    {
        StartCoroutine(Idle());
        switch (estado)
        {
            case Estado.siguiendo:
                E_Seguir();
                break;
            case Estado.atacando:
                E_Atacar();
                break;
            case Estado.muerto:
                agente.enabled = false;
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
        if (cambioDistancia.magnitude<distanciaAtacar)
        {
            CambiarEstado(Estado.atacando);
            agente.SetDestination(transform.position);
        }


    }
    public void E_Atacar()
    {
        Vector3 diferenciaAtacar;
        transform.LookAt(PlayerController.singleton.transform.position, Vector3.up);
        transform.localEulerAngles = Vector3.up * transform.localEulerAngles.y;
        diferenciaAtacar = transform.position - PlayerController.singleton.transform.position; //dejar de atacar
        if (diferenciaAtacar.magnitude > distanciaAtacar + 0.5f)
        {
            CambiarEstado(Estado.siguiendo);
        }
    }

    public void CambiarEstado(Estado nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case Estado.siguiendo:
                animator.SetBool("Atacando", false);
                break;
            case Estado.atacando:
                agente.SetDestination(target.position);
                animator.SetBool("Atacando", true);
                break;
            case Estado.muerto:
                animator.SetBool("Atacando", false);
                break;
            default:
                break;
        }
        estado = nuevoEstado;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bala"))
        {
            Instantiate(particulasGolpe,other.transform.position,other.transform.rotation);
            audioHit.Play();
            vidaEnemigo--;
            if (PowerUps.powerUps.temporadaDa�oDoble)
            {
                vidaEnemigo--;
            }
            Destroy(other.gameObject);
            if (vidaEnemigo<=0)
            {
                muerteOrcoAudio.Play();
                GameManager.singleton.ContadorEnemigos();
                animator.SetTrigger("muerto");
                Destroy(gameObject,10);
                Destroy(col);
                Destroy(rb);
                Destroy(other.gameObject);
                CambiarEstado(Estado.muerto);

            }
        }

    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.up, distanciaAtacar);
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.up, distanciaAtacar+0.5f);
        
    }
#endif
    IEnumerator Idle()
    {
        yield return new WaitForSeconds(3);
        if (inIdle == true)
        {
            animator.SetBool("inidle", true);
        }
    }
}
    public enum Estado
    {   
        siguiendo=0,
        atacando = 1,
        muerto= 2,
    }

