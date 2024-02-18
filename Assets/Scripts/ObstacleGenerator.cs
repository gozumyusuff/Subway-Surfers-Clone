using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private const float yPosition = 0f;
    public GameObject[] ObstaclePrefabs;
    public Transform[] ObstaclePositionZ;
    public Transform[] ObstaclePositionX;


    void Start()
    {
        GenerateObstacles();
    }

    private void GenerateObstacles()
    {
        for (int i = 0; i < ObstaclePositionZ.Length; i++)
        {
            //rastgele engel seçme
            GameObject selectedObstaclePrefab = ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];

            //seçilen prefabi instantiate etme
            GameObject instantiatedObstacle = Instantiate(selectedObstaclePrefab, this.transform);

            //engelin konumu
            instantiatedObstacle.transform.localPosition = new Vector3(
                        ObstaclePositionX[Random.Range(0, ObstaclePositionX.Length)].localPosition.x,
                        yPosition,
                        ObstaclePositionZ[i].localPosition.z);
        }
    }
}
