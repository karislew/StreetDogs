using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //Player location
    public Transform player;
    //Camera's x location
    public float x;
    //Bounds that we will set later (so that camera does not go offscreen)
    public float leftXBound;
    public float rightXBound;
    //Should camera move?
    public bool shouldUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves camera to player's X position if shouldUpdate is true
        if (shouldUpdate)
        {
            x = player.position.x;
            transform.position = new Vector3(x, 0, -10);
        }
    }
}
