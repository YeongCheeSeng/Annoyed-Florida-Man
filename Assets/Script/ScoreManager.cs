using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text ScoreText;

    public static float TotalScore;

    private void Start()
    {
        TotalScore = 0;
    }

    private void Update()
    {
        ScoreText.text = "Score: " + TotalScore;
    }
}
