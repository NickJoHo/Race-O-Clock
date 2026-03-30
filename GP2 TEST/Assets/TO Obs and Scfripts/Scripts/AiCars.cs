using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for UI control

public class AiCars : MonoBehaviour
{
    public float speed = 15.0f;
    public float startDelay = 2.0f;
    public GameObject tintPanel; // Drag your UI Panel here in the Inspector

    private bool canMove = false;

    void Start()
    {
        Invoke("EnableMovement", startDelay);

        // Safety: Make sure the tint is off when we start
        if (tintPanel != null) tintPanel.SetActive(false);
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void EnableMovement()
    {
        canMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 1. Show the tint
            if (tintPanel != null)
            {
                tintPanel.SetActive(true);
            }

            // 2. Freeze the game
            Time.timeScale = 0f;
            Debug.Log("Game Over! Screen Tinted.");
        }
    }
}