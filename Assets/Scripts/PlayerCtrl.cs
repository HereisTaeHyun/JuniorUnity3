using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float gravityModifier;
    private Rigidbody rb;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }
}
