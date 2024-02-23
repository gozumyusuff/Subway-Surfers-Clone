using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.numberOfCoins += 1;
            //coinText.SetText("Coins:" + PlayerController.numberOfCoins);
            coinText.text = "Coins: " + PlayerController.numberOfCoins;
            Destroy(gameObject);
        }
    }
}
//scoreText.text = "Score: " + score.ToString("0");