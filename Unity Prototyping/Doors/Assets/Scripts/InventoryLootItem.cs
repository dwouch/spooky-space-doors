using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a parent class for all items that can be dropped or stored in inventory
public class InventoryLootItem : MonoBehaviour
{
    //Reference ID for item drop logic to refer back to
    public int refID;
    //The name of the item
    public string itemName;
    //The description for the item
    public string itemDescription;
    //Indicates whether the item is a unique type or not
    public bool isUniqueType;
    //Rigidbody
    private Rigidbody obj;


    public virtual void onCreate() { }

    public void use() { }

    public void onDestroy() { }

    public int getRefID()
    {
        return refID;
    }

    public string getName()
    {
        return itemName;
    }

    public string getDescription()
    {
        return itemDescription;
    }

    public bool isUnique()
    {
        return isUniqueType;
    }

}
