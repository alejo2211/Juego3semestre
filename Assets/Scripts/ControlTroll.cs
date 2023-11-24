using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ControlTroll : MonoBehaviour
{

    public Animator animator;
    public float vidaTroll;
    public GameObject particulasGolpe;
    public Collider col1;
    public Collider col2;
    public Rigidbody trollRB;
    

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
                Destroy(gameObject, 10);
                Destroy(col1);
                Destroy(col2);
                Destroy(trollRB);
                Destroy(other.gameObject);
                GetComponent<AI_Enemigo>().CambiarEstado(Estado.muerto);

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