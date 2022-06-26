using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class Glitch : MonoBehaviour
{

    public DigitalGlitch digitalGlitchEffect;
    [Header("Event")]
    public VoidEventChannelSO _GlitchSO;
    public StringEventChannelSO _AudioChannel;

    private void Start()
    {
        _GlitchSO.onEventRaised += ScreenGlitch;
    }

    void ScreenGlitch()
    {
        _AudioChannel.RaiseEvent("Glitch");
        StartCoroutine(screenGlitching());
    }

    IEnumerator screenGlitching()
    {
        digitalGlitchEffect.intensity = Random.Range(0.2f, 0.35f);
        yield return new WaitForSeconds(1.0f);
        digitalGlitchEffect.intensity = 0;
    }

    private void OnDestroy()
    {
        _GlitchSO.onEventRaised -= ScreenGlitch;
    }
}
