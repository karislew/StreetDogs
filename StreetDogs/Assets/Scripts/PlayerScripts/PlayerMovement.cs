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
    public SpriteRenderer speechBubble;

    public Transform feet;
    public Transform raycastOrigin;
    public LayerMask layerMask;
    private RaycastHit2D hit;

    Animator playerAnimator;
    public GameObject playerObj;

    private void Awake()
    {
        //Grabs character controller component
        rb = GetComponent<Rigidbody2D>();

        //Grabs character sprite
        sprite = GetComponent<SpriteRenderer>();

        playerAnimator = GetComponent<Animator>();
        
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        //Creates velocity
        rb.velocity = direction * moveSpeed;
        float animVelocity = Mathf.Abs(rb.velocity.x);
        playerAnimator.SetFloat("velocity", animVelocity);
        //print(animVelocity);

        //Flips sprite and triggers based on direction player is moving
        if (rb.velocity.x > 0)
        {
            playerObj.transform.localPosition = new Vector3(-80.8700027f, 13.183609f, -0.11031574f);
            playerObj.transform.localRotation = new Quaternion(0, -1, 0, 0);
            speechBubble.gameObject.transform.localPosition = new Vector3(6, 2.25f, -0.5f);
            interactionTrigger.offset = new Vector2(1, 0);
            eatingTrigger.offset = new Vector2(1, 0);
        }
        else if (rb.velocity.x < 0)
        {
            playerObj.transform.localPosition = new Vector3(80.8700027f, 13.183609f, -0.11031574f);
            playerObj.transform.localRotation = new Quaternion(0, 0, 0, 0);
            speechBubble.gameObject.transform.localPosition = new Vector3(-6, 2.25f, -0.5f);
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

    private void CheckGround()
    {
        hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down, 100f, layerMask);
        if(hit != false)
        {
            Vector2 temp = feet.position;
            temp.y = hit.point.y;
            feet.position = temp;
        }
    }

}
