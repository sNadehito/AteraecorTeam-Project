using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    bool canInteract = false;
    Coroutine delayCoroutine;
    [Header("Event")]
    public VoidEventChannelSO _voidEventChannelSO;
    public StringEventChannelSO _AudioChannel;
    [Header("Animator")]
    public Animator playerAnim;

    private void OnTriggerEnter(Collider other)
    {
        canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canInteract = false;
    }

    private void Update()
    {
        processInput();
    }

    void processInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canInteract)
        {
            playerAnim.SetBool("isPlayerAct", true);
            delayCoroutine =  StartCoroutine(interactionDelay());
        }
    }

    public void stopDelay() => StopCoroutine(delayCoroutine);

    IEnumerator interactionDelay()
    {
        _AudioChannel.RaiseEvent("Player Action");
        yield return new WaitForSeconds(1.0f);
        playerAnim.SetBool("isPlayerAct", false);
        _voidEventChannelSO.RaiseEvent();
    }
}
