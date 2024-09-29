using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 inputCoords;
    private Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public float moveSpeed;
    public BoxCollider2D interactionTrigger;
    public BoxCollider2D eatingTrigger;

    private void Awake()
    {
        //Grabs character controller component
        rb = GetComponent<Rigidbody2D>();

        //Grabs character sprite
        sprite = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        //Creates velocity
        rb.velocity = direction * moveSpeed;

        //Flips sprite and triggers based on direction player is moving
        if (rb.velocity.x > 0)
        {
            sprite.flipX = true;
            interactionTrigger.offset = new Vector2(1, 0);
            eatingTrigger.offset = new Vector2(1, 0);
        }
        else if (rb.velocity.x < 0)
        {
            sprite.flipX = false;
            interactionTrigger.offset = new Vector2(-1, 0);
            eatingTrigger.offset = new Vector2(-5, 0);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
       //Checks for positive/negative input to determine direction
       inputCoords = context.ReadValue<Vector2>();
       direction = new Vector2(inputCoords.x, inputCoords.y);

    }
}
