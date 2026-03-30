using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 100f;

    public Camera mainCamera;
    public Camera hoodCamera;

    private float moveInput;
    private float turnInput;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Start with main camera enabled
        if (mainCamera != null && hoodCamera != null)
        {
            mainCamera.enabled = true;
            hoodCamera.enabled = false;
        }
    }

    void Update()
    {
        // Get Input (Vertical is W/S or Up/Down, Horizontal is A/D or Left/Right)
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        // Toggle cameras with Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (mainCamera != null && hoodCamera != null)
            {
                mainCamera.enabled = !mainCamera.enabled;
                hoodCamera.enabled = !hoodCamera.enabled;
            }
        }
    }

    void FixedUpdate()
    {
        // MOVE: Changed transform.forward to transform.right 
        // because your model's front is facing the red X-axis.
        Vector3 move = transform.right * moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        // TURN: Rotates the car around the Y-axis (Up)
        if (moveInput != 0) // Only turn if we are actually moving
        {
            // If moving backward (moveInput < 0), we reverse the turn direction
            float modifier = moveInput > 0 ? 1 : -1;
            float turn = turnInput * turnSpeed * Time.fixedDeltaTime * modifier;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}