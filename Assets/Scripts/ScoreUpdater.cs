using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        textMeshPro = GetComponent<TextMeshProUGUI>();
        

    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = score.ToString();
    }
}
