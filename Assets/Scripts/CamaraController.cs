using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform player;
    public float velocidad;
    public Vector3 offset;
    private float angle;

   

    private void Start()
    {
        offset = transform.position - player.position;
    }


    private void Update()
    {
        float hor = Input.GetAxis("Mouse X");
        if (hor!=0)
        {
            angle += hor * Mathf.Rad2Deg;
        }
        Vector3 orbit = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
        transform.position = Vector3.Lerp(transform.position, player.position + offset,velocidad*Time.deltaTime);
        
    }

   


}
