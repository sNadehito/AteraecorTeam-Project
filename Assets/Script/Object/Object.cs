using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Sprite itemSprite;
    public string itemName;
    protected Inventory inventory;
    /// <summary>
    /// Mengatur channel event scriptable objest
    /// masukan InteractEvenetChannel ke dalam _voidEventChannelSO
    /// </summary>

    [Header("Event Channel")]
    public VoidEventChannelSO _InteractionSO;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public virtual void Interact()
    {
        // Object do something
        MoveToInventory();
    }
    /// <summary>
    /// Memindahkan object ke inventory
    /// </summary>
    /// <returns>
    /// true, jika berhasil. false, jika gagal
    /// </returns>
    protected void MoveToInventory()
    {
        inventory.UpdateItem(itemSprite,itemName);
    }


    /// <summary>
    /// Subcribe dan Unsubscribe channel
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        _InteractionSO.onEventRaised += Interact; // subscribe channel
    }

    private void OnTriggerExit(Collider other)
    {
        _InteractionSO.onEventRaised -= Interact; // unsubcsribe channel
    }

    private void OnDestroy()
    {
        _InteractionSO.onEventRaised -= Interact; // unsubscribe channel
    }
}
