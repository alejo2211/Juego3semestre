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
    public bool puertaAbierta;
    public int oleadas;
    public AudioSource audioOrco;
    public Text contadorOleadas;
    public bool armado;
    public void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        contadorMonedas.text = "Monedas: " + moneda.ToString();
        contadorEnemigos.text = "Enemigos derrotados: " + Puntosenemigos.ToString();
    }
    public void StartOleada()
    {
        StartCoroutine(SpawEnemies(orcosTotales));
        audioOrco.Play();

    }

    IEnumerator SpawEnemies(int enemies)
    {

        if ((oleadas+1)%3==0)
        {
            print("se va instanciar un troll");
            Instantiate(trollPrefab, spawnTroll[Random.Range(0, spawnTroll.Length)].position,Quaternion.identity);

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
        if (Puntosenemigos == orcosObjetivos)
        {
            orcosTotales = Mathf.RoundToInt(Mathf.Ceil(orcosTotales * 2f));
            orcosObjetivos += orcosTotales;
            StartCoroutine(SpawEnemies(orcosTotales));
            audioOrco.Play();
            mensajePanel.SetActive(true);
            oleadas++;
            contadorOleadas.text = oleadas.ToString();

        }
        contadorMonedas.text = "Monedas: " + moneda.ToString();
        contadorEnemigos.text = "Enemigos derrotados: " + Puntosenemigos.ToString();


    }
    public void GastarMondeas(int cuanto)
    {
        moneda -= cuanto;
        if (moneda<=0)
        {
            moneda = 0;
        }
        contadorMonedas.text = "Monedas: " + moneda.ToString();

    }

    
   
}
