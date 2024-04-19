using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InteractItem: MonoBehaviour
{
    PickUp pickup;

    bool IsActive = false;

    GameObject Player;

    SpawnUI PickupUI;

    // Update is called once per frame
    void Update()
    {
        if(IsActive == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickupUI.DestroyUI();
                IsActive = false;
                pickup.PickUpItem();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Player = other.gameObject;
        PickupUI = Player.GetComponent<SpawnUI>();
        pickup = Player.GetComponent<PickUp>();

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
