using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public float shotForce = 1500f;
    public float shotRate = 0.5f;
    private float shotRateTime = 0;
    public InputActionProperty dispararBoton;
    public bool presionado;
    public AudioSource audioDisparo;
    private void Start()
    {
        dispararBoton.action.performed += Disparar;

        dispararBoton.action.Enable();
    }
    void Update()
    {

        //if (!presionado)
        //{
        //    if (dispararBoton.action.ReadValue<float>()>0.5)
        //    {
        //        Disparar();
        //        presionado = true;
        //    }
        //}
        //else
        //{
        //    if (dispararBoton.action.ReadValue<float>()<0.1)
        //    {
        //        presionado = false;
        //    }
        //}
    }

    public void Disparar(InputAction.CallbackContext context)
    {
        print("disparando");
        if (Time.time > shotRateTime)
        {
            audioDisparo.Play();
            GameObject newBullet;
            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);
            shotRateTime = Time.time + shotRate;
            Destroy(newBullet, 5);
        }
    }
        

}
