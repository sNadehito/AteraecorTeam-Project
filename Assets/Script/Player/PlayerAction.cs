using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [Header("Event")]
    public VoidEventChannelSO _voidEventChannelSO;
    [Header("Animator")]
    public Animator playerAnim;

    private void Update()
    {
        processInput();
    }

    void processInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetBool("isPlayerAct", true);
            StartCoroutine(interactionDelay());
        }
    }

    IEnumerator interactionDelay()
    {
        yield return new WaitForSeconds(1.0f);
        playerAnim.SetBool("isPlayerAct", false);
        _voidEventChannelSO.RaiseEvent();
    }
}
