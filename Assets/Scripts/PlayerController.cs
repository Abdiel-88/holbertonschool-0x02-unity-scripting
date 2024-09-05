using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;  // Player speed, editable in the Inspector

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the Player object
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called at a fixed interval, best for handling physics
    void FixedUpdate()
    {
        // Get input for movement (WASD or Arrow Keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply the movement to the Rigidbody to move the Player
        rb.AddForce(movement * speed);
    }
}
