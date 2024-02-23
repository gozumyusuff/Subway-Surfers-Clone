using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText; 

    private float score = 0f;
    private float bestScore = 0f;

    private void Start()
    {
        // Baþlangýçta en iyi skoru yükleyin
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreText.text = "Best Score: " + bestScore.ToString("0");
    }

    private void Update()
    {
        // Her saniyede skoru arttýrýn
        score += Time.deltaTime;
        scoreText.text = "Score: " + score.ToString("0");

        // Eðer mevcut skor, en iyi skordan büyükse, en iyi skoru güncelleyin
        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best Score: " + bestScore.ToString("0");

            // En iyi skoru kaydedin
            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
}


