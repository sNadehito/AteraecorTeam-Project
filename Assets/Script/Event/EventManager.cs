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
        if(plant.PlantGrouwth == 3 && plant.growthCounter == 2 && inventory.HasItem("Bucket With Water"))
        {
            StartCoroutine(Glitch());
        }
    }

    IEnumerator Glitch()
    {
        _GlitchChannel.RaiseEvent();
        yield return null;
    }
}
