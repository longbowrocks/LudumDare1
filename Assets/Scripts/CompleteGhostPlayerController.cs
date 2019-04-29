using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGhostPlayerController : MonoBehaviour
{
    public float power;             //Floating point variable to store the player's movement power.
    public float maxSpeed; //Cap for power

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        if (GameController.instance.player1Won)
            HandleControls();
        else
            HandleAIControls();
    }

    void HandleControls()
    {
        if (GameController.instance.currentState == GameController.GameStates.PlaceLoser)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            if (moveHorizontal == 0 && moveVertical == 0)
            {
                rb2d.velocity = rb2d.velocity * 0.8f;
            }
            else
            {
                Vector2 movement = new Vector2(moveHorizontal, moveVertical);
                rb2d.AddForce(movement * power);
                rb2d.velocity = rb2d.velocity * Mathf.Min(maxSpeed / rb2d.velocity.magnitude, 1);
            }
        }
    }

    void HandleAIControls()
    {
        if (GameController.instance.currentState == GameController.GameStates.PlaceLoser)
        {
            // TODO: Do nothing. Use builtin pathfinding and let it control Ghost.
            //rb2d.transform.position = new Vector3(34, -15f, 0);
            rb2d.velocity = new Vector2(34, 15);
            rb2d.velocity = rb2d.velocity * Mathf.Min(maxSpeed / rb2d.velocity.magnitude, 1);
        }
    }
}
