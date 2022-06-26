using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnding : MonoBehaviour
{
    public Animator playerIdleAnim;
    public Sprite playerEndingSprite;
    [Header("Event")]
    public VoidEventChannelSO endingEventChannelSO;

    // Update is called once per frame
    void Awake()
    {
        endingEventChannelSO.onEventRaised += changePlayerSprite;
    }

    void changePlayerSprite()
    {
        playerIdleAnim.enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = playerEndingSprite;
    }

    private void OnDestroy()
    {
        endingEventChannelSO.onEventRaised -= changePlayerSprite;
    }
}
