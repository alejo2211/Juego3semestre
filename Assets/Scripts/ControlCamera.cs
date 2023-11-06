using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class ControlCamera : MonoBehaviour
{
    public InputActionProperty botonApuntar;
    public Transform normal;
    public Transform apuntando;
    private Transform target;
    public float velocidad;
    public Image mira;
    public Color colorNormal;
    public Color colorApuntando;
    public static bool isApuntando;
    public static ControlCamera controlCamera;

    private void Awake()
    {
        controlCamera = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = normal;
        botonApuntar.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, velocidad * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, velocidad * Time.deltaTime);
        if (botonApuntar.action.IsPressed())
        {
            target = apuntando;
            mira.color = Color.Lerp(mira.color, colorApuntando, velocidad * Time.deltaTime);
            isApuntando = true;
        }
        else
        {
            isApuntando = false;
            target = normal;
            mira.color = Color.Lerp(mira.color, colorNormal, velocidad * Time.deltaTime);
        }
    }
}
