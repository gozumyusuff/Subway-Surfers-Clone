using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int targetSide = 1;
    public float sideDistance = 4;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetSide++;
            if (targetSide == 3)
                targetSide = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetSide--;
            if (targetSide == -1)
                targetSide = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (targetSide == 0)
        {
            targetPosition += Vector3.left * sideDistance;
        }else if (targetSide == 2)
        {
            targetPosition += Vector3.right * sideDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
