using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public Text contadorEnemigos;
    public int Puntosenemigos;
    public int moneda;
    public int orcoMoneda=50;
    public Text contadorMonedas;
    public GameObject mensajePanel;
    public int orcosTotales =10;
    public int orcosObjetivos = 10;
    public Transform[] spawnPoints;
    public Transform[] spawnTroll;
    public GameObject trollPrefab;

    public int oleadas;
    public AudioSource audioOrco;
    public Text contadorOleadas;
    public void Awake()
    {
        singleton = this;
    }

    private void Start()
    {

    }
    public void StartOleada()
    {
        StartCoroutine(SpawEnemies(orcosTotales));
        audioOrco.Play();

    }

    IEnumerator SpawEnemies(int enemies)
    {

        if (oleadas%3==0)
        {
            print("se va instanciar un troll");
        }
       
        
            yield return new WaitForSeconds(2);
            mensajePanel.SetActive(false);
            for (int orcos = 0; orcos < orcosTotales; orcos++)
            {
                yield return new WaitForSeconds(2);
                Vector3 pos;
                pos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                GameObject newEnemy = Instantiate(Resources.Load("Enemigo"), pos, Quaternion.identity) as GameObject;
            }
            yield return new WaitForSeconds(3f);
        
        
    }

    public void ContadorEnemigos()
    {
        
        Puntosenemigos++;
        moneda += orcoMoneda;
        contadorMonedas.text = "Monedas: " + moneda.ToString();
        if (Puntosenemigos == orcosObjetivos)
        {
            orcosTotales = Mathf.RoundToInt(Mathf.Ceil(orcosTotales * 1.5f));
            orcosObjetivos += orcosTotales;
            StartCoroutine(SpawEnemies(orcosTotales));
            audioOrco.Play();
            mensajePanel.SetActive(true);
            oleadas++;
            contadorOleadas.text = oleadas.ToString();

        }
        contadorEnemigos.text = Puntosenemigos.ToString();


    }


    
   
}
