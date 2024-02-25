using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText; 

    public float score = 0f;
    private float bestScore = 0f;

    public static GameManager inst;

    private void Awake()
    {
        inst = this;
    }


    private void Start()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreText.text = "Best Score: " + bestScore.ToString("0");
    }

    private void Update()
    {
        score += Time.deltaTime;
        scoreText.text = "Score: " + score.ToString("0");

        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best Score: " + bestScore.ToString("0");

            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save();
        }
    }
}


