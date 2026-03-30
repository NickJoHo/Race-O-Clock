using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{

    public Camera Cam1;
    public Camera Cam2;

    // Start is called before the first frame update
    void Start()
    {
        // Initial required state of the cameras
        Cam1.enabled = true;
        Cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // auto switching state of the cameras on key press
        if (Input.GetButtonDown("CameraSwitch"))
        {
            Cam1.enabled = !Cam1.enabled;
            Cam2.enabled = !Cam2.enabled;
        }
    }
}