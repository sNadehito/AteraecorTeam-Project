using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketEnding : MonoBehaviour
{
    public Animator bucketAnim;
    public Sprite[] bucketSprite = new Sprite[5];
    int bucketNow = 0;
    [Header("Event")]
    public VoidEventChannelSO endingEventChannelSO;

    private void Start()
    {
        bucketNow = 0;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
    void Awake()
    {
        endingEventChannelSO.onEventRaised += itsEnding;
    }

    void itsEnding()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        // bucketAnim.SetBool("isEnding", true);
        StartCoroutine(bucketSpill());
        
    }
    IEnumerator bucketSpill()
    {
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = bucketSprite[++bucketNow];
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = bucketSprite[++bucketNow];
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = bucketSprite[++bucketNow];
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = bucketSprite[++bucketNow];

    }
    private void OnDestroy()
    {
        endingEventChannelSO.onEventRaised -= itsEnding;
    }
}
