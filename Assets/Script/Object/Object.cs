using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [Header("Glitch Need")]
    public Sprite objectSprite;
    public Sprite objectSpriteGlitch;

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

    protected IEnumerator Glitching()
    {
        var counter = 0;
        while (true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = objectSpriteGlitch;
            yield return new WaitForSeconds(0.1f);
            //gameObject.GetComponent<SpriteRenderer>().sprite = objectSprite;
            yield return new WaitForSeconds(0.1f);
            counter++;
            if (counter >= 5)
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = objectSprite;
        yield return null;
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
