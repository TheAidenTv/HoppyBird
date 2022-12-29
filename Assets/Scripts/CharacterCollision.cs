using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public PipeGenerator generator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the character has collided with a pipe
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Bounds")
        {
            // Freeze the character in place
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            generator.setGameOver();
        }
    }
}
