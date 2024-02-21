using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinGenerator : MonoBehaviour
{
    public GameObject[] CoinPrefabs;
    public Transform[] CoinPositionZ;
    public Transform[] CoinPositionX;

    float yPosition = 3.25f;


    void Start()
    {
        GenerateCoins();
    }


    private void GenerateCoins()
    {
        for (int i = 0; i < CoinPositionZ.Length; i++)
        {
            GameObject instantiatedBall = Instantiate(CoinPrefabs[Random.Range(0, CoinPrefabs.Length)], this.transform);

            instantiatedBall.transform.localPosition = new Vector3(CoinPositionX[Random.Range(0, CoinPositionX.Length)].localPosition.x, yPosition, CoinPositionZ[i].localPosition.z);
        }
    }

}