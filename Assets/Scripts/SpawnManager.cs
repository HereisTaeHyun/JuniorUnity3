using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;

    private PlayerCtrl playerCtrl;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float repeatRate;
    private bool isObstacle;
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        isObstacle = false;
    }

    void Update()
    {
        if(isObstacle == false)
        {
            StartCoroutine(SpawnObstacle());
        }
    }

    IEnumerator SpawnObstacle()
    {
        if(playerCtrl.isGameOver == false)
        {
            isObstacle = true;
            repeatRate = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(repeatRate);
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
            isObstacle = false;
        }
    }
}
