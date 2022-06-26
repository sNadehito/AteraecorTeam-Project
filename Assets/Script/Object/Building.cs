using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Object
{
    /// <summary>
    /// Building merukpakan obect diamana harus mencek apakah item yang dibutuhkan untuk melakukan interaction ada
    /// </summary>
    public PlayerNeed playerNeed;
    
    public string itemNeeded;

    public override void Interact()
    {
        if (CheckItem())
        {
            MoveToInventory();
            playerNeed.destroyBucketUI();
        }
        else
        {
            Debug.Log("Player Dont Have Item Needed");
            playerNeed.showObjectNeeded("Bucket");
            // beritahu pemain item apa yang dibutuhkan
        }
    }
    public bool CheckItem()
    {
        if (inventory.HasItem(itemNeeded))
            return true;
        return false;
    }
}
