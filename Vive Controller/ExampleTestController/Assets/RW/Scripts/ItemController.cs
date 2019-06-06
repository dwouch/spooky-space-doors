using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Dictionary<int, InventoryLootItem> commonItems;
    public Dictionary<int, InventoryLootItem> uniqueItems;

    public ItemController() { }
    public int dropItem()
    {
        return 0;
    }
}
