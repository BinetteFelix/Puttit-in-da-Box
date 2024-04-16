using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithApple : MonoBehaviour
{

    bool IsActive = false;

    GameObject Player;

    SpawnUI PickupUI;
    PickUpItem ItemPickUp;

    // Update is called once per frame
    void Update()
    {
        if(IsActive == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickupUI.DestroyUI();
                ItemPickUp.PickUp();
                IsActive = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Player = other.gameObject;
        PickupUI = Player.GetComponent<SpawnUI>();

        if (PickupUI != null)
        {
            PickupUI.PressEtoPickUp();
        }
        IsActive = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Player = other.gameObject;
        PickupUI = Player.GetComponent<SpawnUI>();

        if (PickupUI != null)
        {
            PickupUI.DestroyUI();
        }
        IsActive = false;
    }
}
