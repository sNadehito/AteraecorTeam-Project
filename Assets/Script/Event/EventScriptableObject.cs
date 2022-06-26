using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Datas/ Event Data")]
public class EventScriptableObject : ScriptableObject
{
    public List<GameEvent> gameEvents;
}
