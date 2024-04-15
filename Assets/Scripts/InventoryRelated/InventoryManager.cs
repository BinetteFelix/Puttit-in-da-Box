using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public void Akake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }
}
