using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 inputUsed;
    private CharacterController controller;
    private Vector2 direction;

    public float moveSpeed;

    private void Awake()
    {
        //Grabs character controller component
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Creates velocity
        controller.Move(direction * moveSpeed *  Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
       //Checks for positive/negative input to determine direction
       inputUsed = context.ReadValue<Vector2>();
       direction = new Vector2(inputUsed.x, inputUsed.y);

    }
}
