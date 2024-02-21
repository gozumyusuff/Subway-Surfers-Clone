using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public Rigidbody rb;
    public float maxSpeed;

    public static int numberOfCoins;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    public float jumpForce = 10f;

    private bool isGrounded;

    private void Start()
    {
        numberOfCoins = 0;
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

        if (Input.GetButtonDown("Jump") && isGrounded) // Space tuþuna basýldý ve yerdeysek
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Y ekseninde zýplama kuvveti uygula
            isGrounded = false; // Artýk havadayýz
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Eðer temas ettiðimiz nesne "Ground" etiketine sahipse
        {
            isGrounded = true; // Yerdeyiz
        }
    }
}