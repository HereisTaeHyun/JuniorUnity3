using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isGameOver;
    public ParticleSystem expParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Rigidbody rb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGround && !isGameOver)
        {
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
            playerAnim.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGround = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isGround = true;
        }
        else if(collision.collider.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            expParticle.Play();
            playerAudio.PlayOneShot(crashSound);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            isGameOver = true;
            Debug.Log("GameOver");
        }
    }
}
