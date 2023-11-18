using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    public static MusicaManager musicaManager;
    public AudioSource musicaMenu;
    public AudioSource musicaBatalla;
    public float v;
    private void Awake()
    {
        musicaManager = this;
    }
     void ActualizarMusica(float cancion)
    {
        musicaBatalla.volume = cancion;  //vale 0
        musicaMenu.volume = 1 - cancion;

    }

    IEnumerator Transicion(float destino)
    {
        for (int i = 0; i <= 20; i++)
        {
            ActualizarMusica(Mathf.Lerp(v,destino, i / 20f));
            yield return new WaitForSeconds(i / 20f);
            
        }
        v = destino;


    }

    public void CambiarMusica(float song)
    {
        StartCoroutine(Transicion(song));
    }

}
