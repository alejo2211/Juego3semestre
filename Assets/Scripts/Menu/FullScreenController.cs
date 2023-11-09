using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //No habilita la opción del dropdown

public class FullScreenController : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown dropdownResolution;
    Resolution[] resoluciones;//matriz para guardar las resoluciones de pantalla disponibles en el ordenador

    void Start()
    {
        if(Screen.fullScreen)
        {
           toggle.isOn=true;
        }else
        {
            toggle.isOn=false;
        }
        CheckResolution();
    }

    public void ActivateFullScreen(bool FullScreen)
    {
        Screen.fullScreen=FullScreen;
    }

    public void CheckResolution()
    {
        resoluciones= Screen.resolutions; //Guarda las opciones de resolución disponibles de la pantalla en el arreglo ~ varía según el pc
        dropdownResolution.ClearOptions();//Borramos las opciones por defecto: A,B,C...
        List<string> opciones = new List<string>(); //Creamos una lista del tamaño de la resolución para el dropdown
        int ActualResolution = 0; //Inicializamos variable

        for(int i =0; i < resoluciones.Length; i++ )//Todo depende del número de resoluciones del pc
        {
            string Opcion = resoluciones[i].width + " x " + resoluciones[i].height;//Capturamos los valores de resoluión
            opciones.Add(Opcion);//Asignamos el valor de la resolución a la variable

            if( (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width) &&
            (resoluciones[i].height == Screen.currentResolution.height) )// Revisa si la opción guardada es la configuración actual del equipo
            {
                ActualResolution = i;//Guarda la resolución actual de la pantalla
            }
        }
        dropdownResolution.AddOptions(opciones);//Pasa las resoluciones guardadas en la lista de opciones al dropdown
        dropdownResolution.value = ActualResolution;//Detecta en qué resolción estamos y coloca en el dropdown dicho valor
        dropdownResolution.RefreshShownValue();//Actualiza la lista guardada
        
        dropdownResolution.value =PlayerPrefs.GetInt("ResolutionNumber",0);
    }

    public void CheckResolution(int ResolutionIndex)
    {
        PlayerPrefs.SetInt("ResolutionNumber", dropdownResolution.value);

        Resolution resolution = resoluciones[ResolutionIndex];//
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);//Booleano para detectar la pantalla completa
    }

}
