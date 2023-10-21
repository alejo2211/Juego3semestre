using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textRock;
    public TextMeshProUGUI textDiamond;

    int countCoin;
    int countRock;
    int countDiamond;

    public void AddCoin(int amount) 
    {
        countCoin += amount;
        textCoin.text = countCoin.ToString();
    }

    public void AddRock(int amount)
    {
        countRock += amount;
        textRock.text = countRock.ToString();
    }

    public void AddDiamond(int amount)
    {
        countDiamond += amount;
        textDiamond.text = countDiamond.ToString();
    }
}
