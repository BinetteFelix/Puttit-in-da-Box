using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUp : MonoBehaviour
{

    SpawnUI PickupUI;

    public ItemProfile Item;
    public void PickUpItem()
    {
        InventoryManager.Instance.Add(Item);
        PickupUI.DestroyItem();
    }
}
