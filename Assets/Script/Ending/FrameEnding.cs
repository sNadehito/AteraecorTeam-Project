using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FrameEnding : MonoBehaviour
{
    public Sprite[] endingFrameSprite = new Sprite[4];
    public GameObject gameOverText;
    public GameObject endingFrameObject;
    public Image endingFrameImage;
    int frameNow = -1;
    [Header("Event")]
    public VoidEventChannelSO endingEventChannelSO;

    void Awake()
    {
        endingEventChannelSO.onEventRaised += endFrame;
    }

    void endFrame()
    {
        //endingFrameObject.GetComponent<GameObject>().SetActive(true);
        endingFrameImage.enabled = true;
        StartCoroutine(ChangeEndFrame());
        
    }

    IEnumerator ChangeEndFrame()
    {
        // 1
        yield return new WaitForSeconds(0.5f);
        endingFrameObject.GetComponent<Image>().sprite = endingFrameSprite[++frameNow];
        // 2
        yield return new WaitForSeconds(0.5f);
        endingFrameObject.GetComponent<Image>().sprite = endingFrameSprite[++frameNow];
        // 3
        yield return new WaitForSeconds(0.5f);
        endingFrameObject.GetComponent<Image>().sprite = endingFrameSprite[++frameNow];
        // 4
        yield return new WaitForSeconds(0.5f);
        endingFrameObject.GetComponent<Image>().sprite = endingFrameSprite[++frameNow];
        // Game Over Text
        yield return new WaitForSeconds(0.5f);
        gameOverText.SetActive(true);
        // Load Main Menu
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");

    }

    private void OnDestroy()
    {
        endingEventChannelSO.onEventRaised -= endFrame;
    }
}
