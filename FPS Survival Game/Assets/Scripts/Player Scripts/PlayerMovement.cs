using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    float speed = 5;
    float jumpForce = 4f;
    float gravity = 9.8f;
    float verticalVelocity = 0f;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {

        moveDirection = new Vector3(
            Input.GetAxis(Axis.HORIZONTAL),
            0,
            Input.GetAxis(Axis.VERTICAL)
            );

        moveDirection *= Time.deltaTime * speed;

        ApplyGravity();

        characterController.Move(moveDirection);
    }

    void ApplyGravity()
    {

        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Debug.Log(verticalVelocity);

        moveDirection.y = verticalVelocity * Time.deltaTime;
    }
}
