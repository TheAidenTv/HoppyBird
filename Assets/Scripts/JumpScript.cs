using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Rigidbody2D component of the character
    public Rigidbody2D rb;

    // Force to apply when the character jumps
    public float jumpForce = 10f;

    void Update()
    {
        // Check if the screen was tapped
        if (Input.GetMouseButtonDown(0))
        {
            // Set the character's velocity to an upward force
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
