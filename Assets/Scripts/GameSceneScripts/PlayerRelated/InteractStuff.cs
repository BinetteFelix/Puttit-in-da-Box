using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractStuff: MonoBehaviour
{
    bool IsActive = false;
    bool ItemTouch = false;
    bool RespawnTouch = false;

    GameObject Player;

    UIForRespawn RespawnObject;
    UIForItem ItemObject;
    
    PickUp pickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(IsActive == true)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsActive = false;
                if (ItemTouch == true)
                {
                    pickup.PickUpItem();
                    ItemObject.DestroyUI();
                    ItemTouch = false;
                }
                else if (RespawnTouch == true)
                {
                    RespawnObject.Respawn();
                    RespawnObject.DestroyUI();
                    RespawnTouch = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Player = other.gameObject;
        ItemObject = Player.GetComponent<UIForItem>();
        pickup = Player.GetComponent<PickUp>();
        RespawnObject = Player.GetComponent<UIForRespawn>();
        

        if (ItemObject != null)
        {
            ItemObject.ShowUI();
            ItemTouch = true;
        }
        else if (RespawnObject != null)
        {
            RespawnObject.ShowUI();
            RespawnTouch = true;
        }
        IsActive = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Player = other.gameObject;
        ItemObject = Player.GetComponent<UIForItem>();
        RespawnObject = Player.GetComponent<UIForRespawn>();

        if (ItemObject != null)
        {
            ItemObject.DestroyUI();
            ItemTouch = false;
        }
        else if (RespawnObject != null)
        {
            RespawnObject.DestroyUI();
            RespawnTouch = false;
        }
        IsActive = false;
    }
}
