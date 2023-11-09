using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityController : MonoBehaviour
{
    public TMP_Dropdown dropdownQuality;
    public int Quality;

    void Start()
    {
        Quality = PlayerPrefs.GetInt("QualityNumber",4); //Varible para guardar un valor, se inicia predefinida en 3
        dropdownQuality.value = Quality; //Capturamos el valor de la variable calidad
        QualityAdjust();
    }

    void Update()
    {
        
    }

    public void QualityAdjust()
    {
        QualitySettings.SetQualityLevel(dropdownQuality.value); //Cambiar el valor de unity del projectSettings - Quality al valor que seleccionamos
        PlayerPrefs.SetInt("QualityNumber",dropdownQuality.value); //Cambia el valor de la variable
        Quality=dropdownQuality.value; 
    }
}
