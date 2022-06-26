using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("Script Needed")]
    public Plant plant;
    public Inventory inventory;

    [Header("Event Channel")]
    public VoidEventChannelSO _GlitchChannel;

    public void Update()
    {
        if(plant.PlantGrouwth >= 2)
        {
            switch ((plant.growthCounter, inventory.itemSlots.ItemName)) 
            {
                case (1, "Bucket With Water"):
                    
                case (3, "Fertilizer"):

                case (4, "Bucked"):
                    Pested();
                    break;
            }          //yakin bakal ada bug, terus pested ... ?? gimana cara ngilanginnya      
        }
    }

    IEnumerator Glitch()
    {
        _GlitchChannel.RaiseEvent();
        yield return null;
    }

    public void Pested()
    {
        //plant.isPested = true;
        // tambahin info pested/ gambar tumbuhan kena hama
    }
}
