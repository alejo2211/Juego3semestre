using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform player;
    public float velocidad;
    public Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;
    }


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset,velocidad*Time.deltaTime);
    }

    
}
