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
    public int orcosObjetivos = 10;

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
            pos.x = Random.Range(1, 5);
            pos.y = 2.36f;
            pos.z = -4.357f;
            GameObject newEnemy = Instantiate(Resources.Load("Enemigo"), pos, Quaternion.identity) as GameObject;
        }
        yield return new WaitForSeconds(3f);
    }

    public void ContadorEnemigos()
    {
        Puntosenemigos++;
        if (Puntosenemigos == orcosObjetivos)
        {
            orcosTotales = Mathf.RoundToInt(Mathf.Ceil(orcosTotales * 1.5f));
            orcosObjetivos += orcosTotales;
            StartCoroutine(SpawEnemies(orcosTotales));
            mensajePanel.SetActive(true);

        }
        contadorEnemigos.text = Puntosenemigos.ToString();


    }
   
}
