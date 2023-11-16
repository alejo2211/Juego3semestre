using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movimiento : MonoBehaviour
{
    
    public Vector2 j1;
    public Vector2 j2;
    public InputActionProperty izquierda;
    public InputActionProperty derecha;
    public float velocidad;
    public float velocidadRotacion;
    public Vector3 movimiento;
    public Vector3 direccion;
    public Animator animator;
    public Transform camaraMando;
    public float velocidadH;
    public float velocidadY;
    public Transform rotaCamera;
    public float velocidadRotacionCamera;
    public Vector2 angulos;
    private float t;
    
    void Start()
    {
        izquierda.action.Enable();
        derecha.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        j1 = izquierda.action.ReadValue<Vector2>();
        j2 = derecha.action.ReadValue<Vector2>();
        movimiento.x = j1.x;
        movimiento.z = j1.y;
        movimiento.y = 0;
        movimiento = transform.rotation * movimiento;
        transform.Translate( movimiento * velocidad * Time.deltaTime,Space.World);
        animator.SetFloat("Xspeed", j1.x);
        animator.SetFloat("Yspeed", j1.y);
        direccion.x = j2.x;
        direccion.z= j2.y;


        
        
        if (direccion.sqrMagnitude>0)
        {
            transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime * j2.x);
            t = Mathf.Clamp(t - j2.y * Time.deltaTime * velocidadRotacionCamera, 0f, 1f);
            rotaCamera.localEulerAngles = Vector3.right * Mathf.Lerp(angulos.x, angulos.y, t);
        }       
    }
}
