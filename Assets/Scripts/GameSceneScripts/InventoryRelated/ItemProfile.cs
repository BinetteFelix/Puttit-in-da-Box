using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemProfile : ScriptableObject
{
    public int ID;
    public int value;
    public string itemName;
    public Sprite icon;
}