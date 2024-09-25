using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditorInternal;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject Inventory;
    [SerializeField]
    GameObject AimSightPos;

    public GameObject Player;

    public bool InventoryUI = false;

    public Vector3 CameraLookaround;
    Vector3 velocity;

    float Sensitivity = 10;

    float transitionDuration = 2.5f;
    float t = 0.0f;

    public void resetCam()
    {
        StartCoroutine(LerpToPosition(5, AimSightPos.transform.position, true));
    }

    IEnumerator LerpToPosition(float lerpSpeed, Vector3 newPosition, bool useRelativeSpeed = false)
    {
        if (useRelativeSpeed)
        {
            float totalDistance = AimSightPos.transform.position.x - AimSightPos.transform.position.x;
            float diff = transform.position.x - AimSightPos.transform.position.x;
            float multiplier = diff / totalDistance;
            lerpSpeed *= multiplier;
        }

        float t = 0.0f;
        Vector3 startingPos = transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / lerpSpeed);

            transform.position = Vector3.Lerp(startingPos, newPosition, t);
            yield return 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        //Follow Player
        Vector3 TargetPosition = Player.transform.position + new Vector3(0, 0, -1);
        transform.position = Vector3.SmoothDamp(transform.position, TargetPosition, ref velocity, 0.075f);

        if (InventoryUI == true)
        {
            OpenInventory();
            Cursor.lockState = CursorLockMode.None;
        }
        else if(InventoryUI == false)
        {
            Cursor.lockState = CursorLockMode.Locked;

            //Look around with mouse pointer
            CameraLookaround.x += Input.GetAxis("Mouse X") * Sensitivity;
            CameraLookaround.y += Input.GetAxis("Mouse Y") * Sensitivity;
            CameraLookaround.y = Mathf.Clamp(CameraLookaround.y, -50, 60);

            Player.transform.localRotation = Quaternion.Euler(0, CameraLookaround.x, 0);
            transform.localRotation = Quaternion.Euler(-CameraLookaround.y, CameraLookaround.x, 0);
        }

        if(Input.GetKeyDown(KeyCode.Tab) && InventoryUI == false)
        {
            OpenInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && InventoryUI == true)
        {
            CloseInventory();
        }
    }
    public void OpenInventory()
    {
        Inventory.SetActive(true);
        InventoryUI = true;
    }
    public void CloseInventory()
    {
        Inventory.SetActive(false);
        InventoryUI = false;
    }
}
