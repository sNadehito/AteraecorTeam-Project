using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Object
{
    /// <summary>
    /// Building merukpakan obect diamana harus mencek apakah item yang dibutuhkan untuk melakukan interaction ada
    /// </summary>

    public string itemNeeded;

    public override void Interact()
    {
        if (CheckItem())
            MoveToInventory();
        else
            Debug.Log("Player Dont Have Item Needed");
        // beritahu pemain item apa yang dibutuhkan
    }
    public bool CheckItem()
    {
        if (inventory.HasItem(itemNeeded))
            return true;
        return false;
    }
}
