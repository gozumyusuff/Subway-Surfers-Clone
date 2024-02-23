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
        // Ba�lang��ta en iyi skoru y�kleyin
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreText.text = "Best Score: " + bestScore.ToString("0");
    }

    private void Update()
    {
        // Her saniyede skoru artt�r�n
        score += Time.deltaTime;
        scoreText.text = "Score: " + score.ToString("0");

        // E�er mevcut skor, en iyi skordan b�y�kse, en iyi skoru g�ncelleyin
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


