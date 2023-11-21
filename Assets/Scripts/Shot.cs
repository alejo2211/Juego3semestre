using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shot : MonoBehaviour
{
    public static Shot shot;
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;
    public float modificador;
    public InputActionProperty dispararBoton;
    public bool presionado;
    public AudioSource audioDisparo;
    public int cantidadBalas=10;

    private void Awake()
    {
        shot = this;
    }
    private void Start()
    {
        dispararBoton.action.performed += Disparar;

        dispararBoton.action.Enable();
        modificador = 1;
        cantidadBalas = 10;
        
        
    }
    void Update()
    {


    }

    public void Disparar(InputAction.CallbackContext context)
    {
        if (cantidadBalas>0)
        {

            if (Time.time > shotRateTime && GameManager.singleton.armado)
            {
                cantidadBalas--;
                audioDisparo.Play();
                GameObject newBullet;
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                if (ControlCamera.isApuntando)
                {
                    Ray ray = new Ray(ControlCamera.controlCamera.transform.position, ControlCamera.controlCamera.transform.forward);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 30f))
                    {
                        Vector3 direccion = hit.point - spawnPoint.position;
                        newBullet.GetComponent<Rigidbody>().AddForce(direccion.normalized * shotForce * 2);
                    }
                    else
                    {
                        newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * 2);
                    }
                }
                else
                {
                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce * 2);
                }

                shotRateTime = Time.time + shotRate * modificador;
                Destroy(newBullet, 5);
            }
        }
       
      
        

    }


    public void AumentarMunicion()
    {
        cantidadBalas += 5;
        PowerUps.powerUps.ContadorMunicion();
      
    }
        

}
