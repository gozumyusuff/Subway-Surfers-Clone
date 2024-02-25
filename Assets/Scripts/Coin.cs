using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{


    private void Update()
    {
        transform.Rotate(0, 40 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Obstacle") != null)
        {
            Destroy(gameObject);
            return;
        }

       if (other.gameObject.name != "Player")
        {
            return;
        }

        GameManager.inst.score--;
        Destroy(gameObject);
    }
}
