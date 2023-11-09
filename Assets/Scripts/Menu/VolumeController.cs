using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Nos habilita los comandos del canvas

public class VolumeController : MonoBehaviour
{
    public  Slider slider;
    public float sliderValue;
    public Image imageMute;
    public Image imageNoisy;

    void Start()
    {
        slider.value= PlayerPrefs.GetFloat("AudioVolume", 0.5f); //Guarda la posición del slider de volumen
        AudioListener.volume = slider.value;
        CheckMuteState(); 
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor; //capturamos el valor del slider volumen en el juego
        PlayerPrefs.SetFloat("AudioVolume", sliderValue); //Le asignamos el valor a la variable creada
        AudioListener.volume= slider.value; //
        CheckMuteState();
    }

    public void CheckMuteState()
    {
        if(sliderValue==0)
        {
            imageMute.enabled = true;
        }else
        {
            imageMute.enabled = false;
        }
        if(sliderValue==1)
        {
            imageNoisy.enabled = true;
        }else
        {
            imageNoisy.enabled = false;
        }
    }

}
