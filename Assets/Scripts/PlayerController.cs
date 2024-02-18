using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float sideSpeed = 5f;
    public float jumpForce = 10f;
    bool isMovingSide = false;
    CharacterController controller;
    Vector3 direction;
    public Ease ease;
    private float gravity = -15f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        direction.z = 5;

    }

    private void Move(bool right)
    {
        if (isMovingSide)
        {
            return;
        }
        isMovingSide = true;
        int sign = right ? 1 : -1;  
        transform.DOMoveX(transform.position.x + (sideSpeed * sign), 0.5f).SetEase(ease).OnComplete(()=> isMovingSide = false);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void Update()
    {
        direction.y += gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        controller.Move(direction * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Move(true);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Move(false);
        }
    }




}
