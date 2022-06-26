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
    [Header("Event Pest")]
    public VoidEventChannelSO _PestEvent;
    public override void Interact()
    {
        _PestEvent.RaiseEvent(); // memanggil event pest
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
