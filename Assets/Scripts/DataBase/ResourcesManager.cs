using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public enum GetResources { Barracks, Mine, Bank };
    public GetResources ResourcesType;

    public float time;//Tiempo en el que da recursos
    public int countResources;//Cantidad de recursos
    UIManager uimanager;

    private void Awake()
    {
        uimanager= GameObject.Find("GameManager").GetComponent<UIManager>();
    }

    public void Start()
    {
        switch (ResourcesType)
        {
            case GetResources.Barracks:
                time = 5;
                countResources = 10;
                break;
            case GetResources.Mine:
                time = 3;
                countResources = 15;
                break;
            case GetResources.Bank:
                time = 2;
                countResources = 20;
                break;
        }
        StartCoroutine(Get());
    }

    IEnumerator Get() 
    {
        //float minutos = time * 60;
        yield return new WaitForSeconds(time);

        switch (ResourcesType)
        {
            case GetResources.Barracks:
                uimanager.AddCoin(countResources);
                uimanager.AddRock(countResources);
                break;
            case GetResources.Mine:
                uimanager.AddRock(countResources);
                break;
            case GetResources.Bank:
                uimanager.AddRock(countResources);
                break;
        }
        StartCoroutine(Get());
    }      
}
