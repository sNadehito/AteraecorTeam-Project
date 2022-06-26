using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    Coroutine delayCoroutine;
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
            delayCoroutine =  StartCoroutine(interactionDelay());
        }
        // Test Region
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    this.GetComponent<PlayerNeed>().showObjectNeeded("Fertilizer");
        //}
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    this.GetComponent<PlayerNeed>().showObjectNeeded("Pesticide");
        //}
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    this.GetComponent<PlayerNeed>().showObjectNeeded("Water");
        //}
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    this.GetComponent<PlayerNeed>().destroyItemUI();
        //}
    }

    public void stopDelay() => StopCoroutine(delayCoroutine);

    IEnumerator interactionDelay()
    {
        yield return new WaitForSeconds(1.0f);
        playerAnim.SetBool("isPlayerAct", false);
        _voidEventChannelSO.RaiseEvent();
    }
}
