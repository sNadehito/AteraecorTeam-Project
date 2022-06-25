using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [Header("Event")]
    public VoidEventChannelSO _voidEventChannelSO;
    void Update()
    {
        processInput();   
    }

    void processInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space Pressed");
            _voidEventChannelSO.RaiseEvent();
        }
    }
}
