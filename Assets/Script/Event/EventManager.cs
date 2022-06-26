using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("Script Needed")]
    public Plant plant;
    public Building well;
    public Inventory inventory;
    [Header("Database")]
    public EventScriptableObject pestEventData;
    public EventScriptableObject glitchEventData;
    public Queue<GameEvent> pestEventQueue = new Queue<GameEvent>();
    public Queue<GameEvent> glitchEventQueue = new Queue<GameEvent>();
    [Header("Event Channel")]
    public VoidEventChannelSO _GlitchChannel;
    public VoidEventChannelSO _PestChannel;
    public VoidEventChannelSO _CheckEventChennel;
    public StringEventChannelSO _AudioChannel;

    public void Awake()
    {
        _PestChannel.onEventRaised += CheckPestEvent;
        _CheckEventChennel.onEventRaised += CheckGlitchEvent;
    }

    private void Start()
    {
        _AudioChannel.RaiseEvent("Background Music");
        DataBaseQueue();    
    }

    private void DataBaseQueue()
    {
        foreach (GameEvent p in pestEventData.gameEvents)
        {
            Debug.Log("Stage : " + p.stage + " Plant Growth : " + p.plantGrowth + " Item Name : " + p.itemInventory);
            pestEventQueue.Enqueue(p);
        }
        foreach (GameEvent p in glitchEventData.gameEvents)
        {
            Debug.Log("Stage : " + p.stage + " Plant Growth : " + p.plantGrowth + " Item Name : " + p.itemInventory);
            glitchEventQueue.Enqueue(p);
        }
    }

    private void CheckPestEvent()
    {
        Debug.Log("Check Event Pest");

        foreach (GameEvent p in pestEventQueue)
        {
            if (plant.PlantGrowth == p.stage && 
                plant.growthCounter == p.plantGrowth && 
                inventory.itemSlots.ItemName == p.itemInventory)
            {
                pestEventQueue.Dequeue();
                Pested();
                break;
            }
                
        }
    }

    private void CheckGlitchEvent()
    {
        Debug.Log("Check Event Glitch");

        foreach (GameEvent p in glitchEventQueue)
        {
            if (plant.PlantGrowth == p.stage &&
                plant.growthCounter == p.plantGrowth &&
                inventory.itemSlots.ItemName == p.itemInventory)
            {
                glitchEventQueue.Dequeue();
                _GlitchChannel.RaiseEvent();
                break;
            }

        }
    }

    public void Pested()
    {
        Debug.Log("Pested");
        plant.isPested = true;
        // tambahin info pested/ gambar tumbuhan kena hama
    }

    private void OnDestroy()
    {
        _PestChannel.onEventRaised -= CheckPestEvent;
        _CheckEventChennel.onEventRaised -= CheckGlitchEvent;
    }
}
