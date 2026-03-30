using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlle : MonoBehaviour
{
    public float speed = 15.0f;
    public float turnSpeed = 100.0f;

    void Update()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Move using 'right' for your 90-degree model
        transform.Translate(Vector3.right * moveInput * speed * Time.deltaTime);

        if (moveInput != 0)
        {
            transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
        }
    }

    // This part handles the specific freezing logic
    private void OnCollisionEnter(Collision collision)
    {
        // Only freeze if the object we touched has the "Obstacle" tag
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f; // Freeze the game
            Debug.Log("Game Over! You hit: " + collision.gameObject.name);
        }
    }
}