using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{

    public Vector3 velocidad;
    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(velocidad * Time.deltaTime);
    }
}
