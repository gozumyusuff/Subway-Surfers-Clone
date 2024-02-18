using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject PathPrefab;

    public int PathNumber;
    //float previousZPosition;

    private void Start()
    {
        GeneratePaths();
    }

    private void GeneratePaths()
    {
        int zPositition = -100;
        for (int i = 0; i < PathNumber; i++)
        {
            zPositition += 100;
            GameObject instantiatedPath = Instantiate(PathPrefab, this.transform);
            instantiatedPath.transform.localPosition = new Vector3(0, 0, zPositition);
        }
    }

}