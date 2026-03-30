using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlle : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 15.0f;
    public float startDelay = 2.0f;

    [Header("UI & Audio")]
    public GameObject tintPanel; // Drag your Panel here

    private AudioSource crashSound; // The AudioSource on THIS car
    private bool canMove = false;

    void Start()
    {
        // Gets the "Wasted" sound component from this car
        crashSound = GetComponent<AudioSource>();

        // Hide tint at start
        if (tintPanel != null) tintPanel.SetActive(false);

        Invoke("EnableMovement", startDelay);
    }

    void Update()
    {
        if (canMove)
        {
            // Moves the car based on its local right (Red axis)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void EnableMovement()
    {
        canMove = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the car hit the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WastedSequence());
        }
    }

    IEnumerator WastedSequence()
    {
        // 1. Play the "Wasted" sound effect
        if (crashSound != null)
        {
            crashSound.Play();
        }

        // 2. Find the Background Music and Stop it
        // Make sure your BGM object has the Tag "Music"
        GameObject bgmObject = GameObject.FindWithTag("Music");
        if (bgmObject != null)
        {
            AudioSource bgmSource = bgmObject.GetComponent<AudioSource>();
            if (bgmSource != null)
            {
                bgmSource.Stop();
            }
        }

        // 3. Show the Game Over / Tint Panel
        if (tintPanel != null)
        {
            tintPanel.SetActive(true);
        }

        // 4. Wait for a tiny heartbeat so the sound actually starts
        // We use Realtime because timeScale 0 will stop regular WaitForSeconds
        yield return new WaitForSecondsRealtime(0.02f);

        // 5. Freeze the game
        Time.timeScale = 0f;

        Debug.Log("Game Over: Time Frozen.");
    }
}