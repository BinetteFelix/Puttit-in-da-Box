using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_and_Follow : MonoBehaviour
{
    [SerializeField]
    GameObject Camera;

    float Sensitivity = 10;
    Vector3 velocity;
    public Vector3 CameraLookaround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 TargetPosition = Camera.transform.position + new Vector3(5, -1, 10);
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity, 0.05f);

        CameraLookaround.x += Input.GetAxis("Mouse X") * Sensitivity;
        CameraLookaround.y += Input.GetAxis("Mouse Y") * Sensitivity;
        Camera.transform.localRotation = Quaternion.Euler(-CameraLookaround.y, CameraLookaround.x, 0);
    }
}
