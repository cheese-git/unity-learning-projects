using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    float speed = 5;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        moveDirection = new Vector3(
            Input.GetAxis(Axis.HORIZONTAL),
            0,
            Input.GetAxis(Axis.VERTICAL)
            );

        moveDirection *= Time.deltaTime * speed;

        characterController.Move(moveDirection);
    }
}
