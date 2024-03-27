using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    public Vector3 CameraLookaround;
    float Sensitivity = 10;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Follow Player
        Vector3 TargetPosition = Player.transform.position + new Vector3(0, 0, -1);
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity, 0.135f);
        
        //Look around with mouse pointer
        CameraLookaround.x += Input.GetAxis("Mouse X") * Sensitivity;
        CameraLookaround.y += Input.GetAxis("Mouse Y") * Sensitivity;
        Player.transform.localRotation = Quaternion.Euler(-CameraLookaround.y, CameraLookaround.x, 0);
        transform.localRotation = Quaternion.Euler(-CameraLookaround.y, CameraLookaround.x, 0);
    }
}
