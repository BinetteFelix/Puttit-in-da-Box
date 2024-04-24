using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class InteractStuff: MonoBehaviour
{
    bool IsActive = false;
    bool ItemTouch = false;
    bool RespawnTouch = false;

    GameObject Player;

    UIForRespawn IsRespawn;
    UIForItem IsItem;
    
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
                    IsItem.DestroyUI();
                    ItemTouch = false;
                }
                else if (RespawnTouch == true)
                {
                    IsRespawn.Respawn();
                    IsRespawn.DestroyUI();
                    RespawnTouch = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Player = other.gameObject;
        IsItem = Player.GetComponent<UIForItem>();
        pickup = Player.GetComponent<PickUp>();
        IsRespawn = Player.GetComponent<UIForRespawn>();
        

        if (IsItem != null)
        {
            IsItem.ShowUI();
            ItemTouch = true;
        }
        else if (IsRespawn != null)
        {
            IsRespawn.ShowUI();
            RespawnTouch = true;
        }
        IsActive = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Player = other.gameObject;
        IsItem = Player.GetComponent<UIForItem>();
        IsRespawn = Player.GetComponent<UIForRespawn>();

        if (IsItem != null)
        {
            IsItem.DestroyUI();
            ItemTouch = false;
        }
        else if (IsRespawn != null)
        {
            IsRespawn.DestroyUI();
            RespawnTouch = false;
        }
        IsActive = false;
    }
}
