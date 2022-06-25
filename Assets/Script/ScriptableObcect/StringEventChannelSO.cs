using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/String Event Channel")]
public class StringEventChannelSO : ScriptableObject
{
    public UnityAction<string> onEventRaised;
    public void RaiseEvent(string name)
    {
        if (onEventRaised != null)
            onEventRaised.Invoke(name);
        else
            Debug.LogWarning("Event Requested, but no one picked it up");
    }
}
