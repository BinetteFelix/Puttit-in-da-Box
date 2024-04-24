using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemProfile> Items = new List<ItemProfile>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public void Awake()
    {
        Instance = this;
    }

    public void Add(ItemProfile item)
    {
        Items.Add(item);
    }

    public void ArrangeItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(var item in Items)
        {
            GameObject ItemObject = Instantiate(InventoryItem, ItemContent);

            var itemIcon = ItemObject.transform.Find("ItemIcon").GetComponent<Image>();
            var itemName = ItemObject.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();

            itemIcon.sprite = item.icon;
            itemName.text = item.itemName;
        }
    }
}
