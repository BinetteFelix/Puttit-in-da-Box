using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractStuff: MonoBehaviour
{
    bool IsActive = false;
    bool InRangeOfItem = false;
    bool InRangeForRespawn = false;

    GameObject Player;

    UIForRespawn RespawnPoint;
    UIForItem ItemObject;
    
    PickUp pickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If Pick-up UI is active
        if(IsActive == true)
        {   
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsActive = false;
                if (InRangeOfItem == true)
                {
                    pickup.PickUpItem();
                    ItemObject.DestroyUI();
                    InRangeOfItem = false;
                }
                else if (InRangeForRespawn == true)
                {
                    RespawnPoint.Respawn();
                    RespawnPoint.DestroyUI();
                    InRangeForRespawn = false;
                }
            }
        }
    }
    //When You are in range of item/Respawn point. When you enter the IsTrigger collider on the item/Respawn point objects
    private void OnTriggerEnter(Collider other)
    {
        Player = other.gameObject;
        ItemObject = Player.GetComponent<UIForItem>();
        pickup = Player.GetComponent<PickUp>();
        RespawnPoint = Player.GetComponent<UIForRespawn>();
        
        //For when you hit ItemObject's Range/enter the IsTrigger collider
        if (ItemObject != null)
        {
            ItemObject.ShowUI();
            InRangeOfItem = true;
        }
        //For when you hit the respawn point's range/enter the IsTrigger collider
        else if (RespawnPoint != null)
        {
            RespawnPoint.ShowUI();
            InRangeForRespawn = true;
        }
        IsActive = true;
    }
    //When You are not in range of item/Respawn point. When you exit the IsTrigger collider on the item/Respawn point objects
    private void OnTriggerExit(Collider other)
    {
        Player = other.gameObject;
        ItemObject = Player.GetComponent<UIForItem>();
        RespawnPoint = Player.GetComponent<UIForRespawn>();

        //For when you Leave ItemObject's Range/Exit the IsTrigger collider
        if (ItemObject != null)
        {
            ItemObject.DestroyUI();
            InRangeOfItem = false;
        }
        //For when you Leave the respawn point's range/Exit the IsTrigger collider
        else if (RespawnPoint != null)
        {
            RespawnPoint.DestroyUI();
            InRangeForRespawn = false;
        }
        IsActive = false;
    }
}
