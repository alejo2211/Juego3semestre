using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;

    public float horizontalMove;
    public float verticalMove;
    public CharacterController player;
    private Vector3 playerInput;

    public float speed;
    private Vector3 movePlayer;

    public Camera mainCam;
    private Vector3 camForward;
    private Vector3 camRight;

    public int vidaMaximaPlayer = 100;
    private int vidaActualPlayer;
    public Text textoVida;
    private void Awake()
    {
        singleton = this;
    }
    void Start()
    {
        player = GetComponent<CharacterController>();
        vidaActualPlayer = vidaMaximaPlayer;

    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + movePlayer);

        player.Move(movePlayer * speed * Time.deltaTime);
        
                
    }
    void camDirection()
    {
        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    public void RecibirDaño(int cantidadDaño)
    {
        Debug.Log("daño causado" + cantidadDaño);
        vidaActualPlayer -= cantidadDaño;
        if (vidaActualPlayer == 0)
        {
            //Metodo o Estado Morir
            Debug.Log("Muerto......");

            Destroy(gameObject);

            SceneManager.LoadScene("GameOver");


        }
        ActualizarTextoVida();
    }

    public void ActualizarTextoVida()
    {
        if (textoVida != null)
        {
            textoVida.text = " " + vidaActualPlayer.ToString();
        }
    }

}
