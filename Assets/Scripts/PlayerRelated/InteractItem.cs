using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class InteractItem: MonoBehaviour
{
    bool IsActive = false;
    bool ItemTouch = false;
    bool RespawnTouch = false;

    GameObject Player;

    UIForRespawn IsRespawn;
    UIForItem IsItem;
    EnemySpawner SpawnEnemies;
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
                    SpawnEnemies.SpawnEnemy1();
                    SpawnEnemies.SpawnEnemy2();
                    IsRespawn.WalkedAwayFromWall();
                    RespawnTouch = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Player = other.gameObject;
        IsItem = Player.GetComponent<UIForItem>();
        IsRespawn = Player.GetComponent<UIForRespawn>();
        pickup = Player.GetComponent<PickUp>();
        SpawnEnemies = Player.GetComponent<EnemySpawner>();

        if (IsItem != null)
        {
            IsItem.PressEtoPickUp();
            ItemTouch = true;
        }
        else if (IsRespawn != null)
        {
            IsRespawn.PressEForRespawn();
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
            IsRespawn.WalkedAwayFromWall();
            RespawnTouch = false;
        }
        IsActive = false;
    }
}
