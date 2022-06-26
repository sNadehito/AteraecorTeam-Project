using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Sprite objectSprite;

    public Sprite itemSprite;
    public string itemName;
    [SerializeField]
    protected Inventory inventory;
    /// <summary>
    /// Mengatur channel event scriptable objest
    /// masukan InteractEvenetChannel ke dalam _voidEventChannelSO
    /// </summary>

    [Header("Event Channel")]
    public VoidEventChannelSO _InteractionEvent;
    public VoidEventChannelSO _GlitchEvent;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = objectSprite;
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
    
    public virtual void Glitch()
    {
       /// glitch
        
    }

    /// <summary>
    /// Subcribe dan Unsubscribe channel
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        _InteractionEvent.onEventRaised += Interact; // subscribe channel
    }

    private void OnTriggerExit(Collider other)
    {
        _InteractionEvent.onEventRaised -= Interact; // unsubcsribe channel
    }

    private void OnDestroy()
    {
        _InteractionEvent.onEventRaised -= Interact; // unsubscribe channel
    }
}
