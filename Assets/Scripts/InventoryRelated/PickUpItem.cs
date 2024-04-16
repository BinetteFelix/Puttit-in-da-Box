using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item Item;

    //remove Item from map
    SpawnUI RemoveItem;
    public void PickUp()
    {
        InventoryManager.Instance.Add(Item);
        RemoveItem.DestroyItem();
    }
}
