using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGlitch : MonoBehaviour
{
    [Header("Glitch Image")]
    public Sprite grassNormal;
    public Sprite grassGlitch;
    public Sprite treeNormal;
    public Sprite treeGlitch;
    [Header("List Of Object")]
    public GameObject tree;
    public GameObject grass;
    public List<SpriteRenderer> grasses = new List<SpriteRenderer>();
    public List<SpriteRenderer> trees = new List<SpriteRenderer>();
    [Header("Event Channel")]
    public VoidEventChannelSO _GlitchChannel;

    private void Awake()
    {
        _GlitchChannel.onEventRaised += Glitch;
    }

    private void Start()
    {
        grasses = new List<SpriteRenderer>();
        trees = new List<SpriteRenderer>();
        ListEnvironment();
    }

    private void ListEnvironment()
    {
        foreach (Transform s in tree.transform)
        {
            Debug.Log("add tree");
            trees.Add(s.GetComponent<SpriteRenderer>());
        }
        foreach (Transform s in grass.transform)
        {
            grasses.Add(s.GetComponent<SpriteRenderer>());
        }
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
            foreach(SpriteRenderer s in grasses)
            {
                s.sprite = grassGlitch;
            }
            foreach(SpriteRenderer s in trees)
            {
                s.sprite = treeGlitch;
            }
            yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(0.1f);
            counter++;
            if (counter >= 5)
                break;
        }
        foreach (SpriteRenderer s in grasses)
        {
            s.sprite = grassNormal;
        }
        foreach (SpriteRenderer s in trees)
        {
            s.sprite = treeNormal;
        }
        yield return null;
    }
    private void OnDestroy()
    {
        _GlitchChannel.onEventRaised -= Glitch;
    }
}
