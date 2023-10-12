using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public Text contadorEnemigos;
    public int Puntosenemigos;
    public GameObject mensajePanel;
    public int orcos;
    public int orcosTotales =10;

    public void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        StartCoroutine(SpawEnemies(orcosTotales));

    }

    IEnumerator SpawEnemies(int enemies)
    {
        yield return new WaitForSeconds(2);
        mensajePanel.SetActive(false);
        for (int orcos = 0; orcos < orcosTotales; orcos++)
        {
            yield return new WaitForSeconds(2);
            Vector3 pos;
            pos.x = Random.Range(-5, 50);
            pos.y = 0;
            pos.z = -49.09f;
            GameObject newEnemy = Instantiate(Resources.Load("Enemigo"), pos, Quaternion.identity) as GameObject;
        }
        yield return new WaitForSeconds(3f);
    }

    public void ContadorEnemigos()
    {
        Puntosenemigos++;
        if (Puntosenemigos == 10)
        {

            StartCoroutine(SpawEnemies(orcosTotales));
            mensajePanel.SetActive(true);

        }

        if (Puntosenemigos == 20)
        {
            StartCoroutine(SpawEnemies(orcosTotales));
            mensajePanel.SetActive(true);
        }  
        
        if (Puntosenemigos == 30)
        {
            StartCoroutine(SpawEnemies(orcosTotales));
            mensajePanel.SetActive(true);
        } 
        
        if (Puntosenemigos == 40)
        {
            StartCoroutine(SpawEnemies(orcosTotales));
            mensajePanel.SetActive(true);
        } 
        
        if (Puntosenemigos == 50)
        {
            StartCoroutine(SpawEnemies(orcosTotales));
            mensajePanel.SetActive(true);
        }

        

        contadorEnemigos.text = Puntosenemigos.ToString();


    }
    }
