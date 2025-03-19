using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private float leftBound = -15.0f;
    private PlayerCtrl playerCtrl;
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }
    void Update()
    {
        if(playerCtrl.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if(transform.position.x < leftBound && transform.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
