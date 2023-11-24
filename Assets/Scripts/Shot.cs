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
    public int cantidadBalas=400;

    private void Awake()
    {
        shot = this;
    }
    private void Start()
    {
        dispararBoton.action.performed += Disparar;
        dispararBoton.action.Enable();
        modificador = 1;
        cantidadBalas = 400;
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
                PowerUps.powerUps.ContadorMunicion();
                audioDisparo.Play();
                GameObject newBullet;
                Vector3 fuerza= Vector3.zero;

                if (ControlCamera.isApuntando)
                {
                    Ray ray = new Ray(ControlCamera.controlCamera.transform.position, ControlCamera.controlCamera.transform.forward);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 30f))
                    {
                        Vector3 direccion = hit.point - spawnPoint.position;
                        fuerza=(direccion.normalized * shotForce * 2);
                    }
                    else
                    {
                        fuerza=(spawnPoint.forward * shotForce * 2);
                    }
                }
                else
                {
                    fuerza=(spawnPoint.forward * shotForce * 2);
                }
                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(fuerza);

                shotRateTime = Time.time + shotRate * modificador;
                Destroy(newBullet, 5);
            }
        }
       
      
        

    }


    public void AumentarMunicion()
    {
        cantidadBalas += 100;
        PowerUps.powerUps.ContadorMunicion();
      
    }
        

}
