using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public Rigidbody rb;
    public float maxSpeed;

    private Animator animator;

    private CapsuleCollider capsuleCollider;

    public static int numberOfCoins;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float jumpForce = 10f;

    private bool isGrounded;

    private void Start()
    {
        numberOfCoins = 0;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * forwardSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * forwardSpeed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        // hýzý gitgide arttýrma
        if (forwardSpeed < maxSpeed) 
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }
       
        horizontalInput = Input.GetAxis("Horizontal");
        horizontalInput = Mathf.Clamp(horizontalInput, -3f, 3f);   

        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            animator.SetTrigger("isJump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isGrounded = false; 
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {
            animator.SetTrigger("isSlide");
            
            //isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true; 
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerManager.gameOver = true;
        }

       
    }
}