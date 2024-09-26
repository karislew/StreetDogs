using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 inputCoords;
    private Vector2 direction;
    private CharacterController controller;
    private SpriteRenderer sprite;

    public float moveSpeed;
    public BoxCollider2D interactionTrigger;

    private void Awake()
    {
        //Grabs character controller component
        controller = GetComponent<CharacterController>();

        //Grabs character sprite
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        //Creates velocity
        controller.Move(direction * moveSpeed *  Time.deltaTime);

        //Flips sprite and interaction trigger based on direction player is moving
        if (controller.velocity.x > 0)
        {
            sprite.flipX = true;
            interactionTrigger.offset = new Vector2(1, 0);
        }
        else if (controller.velocity.x < 0)
        {
            sprite.flipX = false;
            interactionTrigger.offset = new Vector2(-1, 0);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
       //Checks for positive/negative input to determine direction
       inputCoords = context.ReadValue<Vector2>();
       direction = new Vector2(inputCoords.x, inputCoords.y);

    }
}
