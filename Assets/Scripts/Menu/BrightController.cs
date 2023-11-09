using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //habilita las opciones de la interfaz de usuario.

public class BrightController : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image PanelBright; // componente al que se le vaa cambiar el alfa

    void Start()
    {
        slider.value=PlayerPrefs.GetFloat("Bright",0.5f); //Varible donde gurda el valor de la configuración
        PanelBright.color= new Color(PanelBright.color.r, PanelBright.color.g, PanelBright.color.b, slider.value);
    }

    public void ChangeBright(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Bright", sliderValue); //EN este punto se guarda el nuevo valor de alfa
        PanelBright.color= new Color(PanelBright.color.r, PanelBright.color.g, PanelBright.color.b, slider.value); //Actualiza el alfa

    }
}
