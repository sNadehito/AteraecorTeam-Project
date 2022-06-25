using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    bool istrue = true;
    IEnumerator Glitch()
    {
        yield return new WaitUntil(() => istrue);
        // do glitch
    }
}
