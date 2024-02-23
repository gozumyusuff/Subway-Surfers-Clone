using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Position
{
    LEFT,
    MID,
    RIGHT,
}

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

    bool isMoving = false;

    private bool isGrounded;

    private Position currentPosition;
    private float positionValue;

    private void Start()
    {
        numberOfCoins = 0;
        animator = GetComponent<Animator>();
        currentPosition = Position.MID;
        
    }

    private void Update()
    {
       
        // hýzý gitgide arttýrma
        if (forwardSpeed < maxSpeed) 
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            animator.SetTrigger("isJump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isGrounded = false; 
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {
            animator.SetTrigger("isSlide");
            // scale küçülücek
            //isGrounded = false;
        }

        if (isMoving)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.D) && Mathf.RoundToInt(transform.position.x) < 3f)
        {
            MoveToPosition(Mathf.RoundToInt(transform.position.x) + 3);
        }
        else if (Input.GetKeyDown(KeyCode.A) && Mathf.RoundToInt(transform.position.x) > -3f)
        {
            MoveToPosition(Mathf.RoundToInt(transform.position.x) - 3);
        }
    }


    private void MoveToPosition(float targetX)
    {
        StartCoroutine(MoveToPositionCoroutine(targetX));
    }

    private IEnumerator MoveToPositionCoroutine(float targetPositionX)
    {
        isMoving = true;
        while (Mathf.Abs(targetPositionX - rb.position.x) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPositionX,rb.position.y,rb.position.z), horizontalMultiplier * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
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