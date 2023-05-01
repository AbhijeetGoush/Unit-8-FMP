using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    CoinScript coin;
    // Start is called before the first frame update
    void Start()
    {
        coin = GetComponent<CoinScript>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        coin.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = coin.score.ToString();
    }
}
