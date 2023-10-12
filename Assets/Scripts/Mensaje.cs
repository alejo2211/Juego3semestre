using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mensaje : MonoBehaviour
{
    public float tiempoDeMostrado = 5f;
    private TextMeshProUGUI mensajeTexto;

    private void Start()
    {
        mensajeTexto = GetComponent<TextMeshProUGUI>();
        // Mostrar el mensaje al inicio
        mensajeTexto.enabled = true;
        // Iniciar una corutina para ocultar el mensaje después de cierto tiempo
        StartCoroutine(OcultarMensaje());
    }

    private IEnumerator OcultarMensaje()
    {
        // Esperar durante el tiempo especificado antes de ocultar el mensaje
        yield return new WaitForSeconds(tiempoDeMostrado);
        // Ocultar el mensaje
        mensajeTexto.enabled = false;
    }
}
