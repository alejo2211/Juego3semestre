using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ControlTroll : MonoBehaviour
{
    public Transform jugador;
    public NavMeshAgent agente;
    public Animator animator;
    public EstadoTroll estado;
    public float distanciaAtacarTroll;
    public float vidaTroll;
    public GameObject particulasGolpe;

}
public enum EstadoTroll
{
    siguiendo = 0,
    atacando = 1,
    muerto = 2,
}