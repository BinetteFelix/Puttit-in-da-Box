using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class PickUp : MonoBehaviour
{

    public ItemProfile Item;
    public void PickUpItem()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

}
