using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.numberOfCoins += 1;
            Debug.Log("Coins:" + PlayerController.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
