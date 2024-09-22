using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDog : MonoBehaviour
{
    //Movement distance
    private Vector2 movement;
    //Movement time/speed
    public float moveSpeed;
    //Should player move?
    public bool canMove;
    //Player's rigidbody component
    public Rigidbody2D rb;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calculates move distance when canMove is true
        if (canMove)
        {
            ManageMovement();
        }
    }

    
    private void FixedUpdate()
    {
        //Allows player to move when canMove is true
        if (canMove)
        {
            //Propels player object (movement is negative for left, positive for right)
            rb.velocity = movement * moveSpeed;
        }
    }

    
    void ManageMovement()
    {
        //Registers input for moving left and right
        float mx = Input.GetAxisRaw("Horizontal");
        //Y coord is 0 because no vertical movement
        movement = new Vector2(mx, 0).normalized;
    }
}
