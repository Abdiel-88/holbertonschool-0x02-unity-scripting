using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;  // Player speed, editable in the Inspector
    public int health = 5;       // New public variable to track health

    private Rigidbody rb;
    private int score = 0;       // Existing score variable

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

    // Called when another collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            // Increment the score
            score++;
            // Log the new score
            Debug.Log($"Score: {score}");
            // Disable the Coin object
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Trap"))
        {
            // Decrement the health
            health--;
            // Log the new health value
            Debug.Log($"Health: {health}");
            // Optionally, disable or destroy the Trap object if needed
            // other.gameObject.SetActive(false);
        }
    }
}
