using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGlitch : MonoBehaviour
{
    [Header("Ground Material")]
    public Material groundNormal;
    public Material groundGlitch;
    [Header("The Ground")]
    public MeshRenderer ground;
    [Header("Event Channel")]
    public VoidEventChannelSO _GlitchChannel;

    private void Awake()
    {
        _GlitchChannel.onEventRaised += Glitch;
    }

    private void Start()
    {
        ground = gameObject.GetComponent<MeshRenderer>();
    }

    public void Glitch()
    {
        StartCoroutine(Glitching());
    }
    IEnumerator Glitching()
    {
        var counter = 0;
        while (true)
        {
            ground.material = groundGlitch;
            yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(0.1f);
            counter++;
            if (counter >= 5)
                break;
        }
        ground.material = groundNormal;
        yield return null;
    }
    private void OnDestroy()
    {
        _GlitchChannel.onEventRaised -= Glitch;
    }
}
