using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public UnityAction onEventRaised;
    public void RaiseEvent()
    {
        if (onEventRaised != null)
            onEventRaised.Invoke();
        else
            Debug.LogWarning("Event Requested, but no one picked it up");
    }

}