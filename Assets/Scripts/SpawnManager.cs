using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }
}
