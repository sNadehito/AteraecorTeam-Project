using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGlitch : MonoBehaviour
{
    [Header("Glitch Image")]
    public Sprite grassNormal;
    public Sprite grassGlitch;
    public Sprite[] treeNormal = new Sprite[2];
    public Sprite[] treeGlitch = new Sprite[2];
    [Header("List Of Object")]
    public GameObject[] tree = new GameObject [2];
    public GameObject grass;
    public List<SpriteRenderer> grasses = new List<SpriteRenderer>();
    public List<SpriteRenderer> trees1 = new List<SpriteRenderer>();
    public List<SpriteRenderer> trees2 = new List<SpriteRenderer>();
    [Header("Event Channel")]
    public VoidEventChannelSO _GlitchChannel;

    private void Awake()
    {
        _GlitchChannel.onEventRaised += Glitch;
    }

    private void Start()
    {
        grasses = new List<SpriteRenderer>();
        trees1 = new List<SpriteRenderer>();
        ListEnvironment();
    }

    private void ListEnvironment()
    {
        foreach (Transform s in tree[0].transform)
        {
            Debug.Log("add tree");
            trees1.Add(s.GetComponent<SpriteRenderer>());
        }
        foreach (Transform s in tree[1].transform)
        {
            Debug.Log("add tree");
            trees2.Add(s.GetComponent<SpriteRenderer>());
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
            foreach(SpriteRenderer s in trees1)
            {
                s.sprite = treeGlitch[0];
            }
            foreach (SpriteRenderer s in trees2)
            {
                s.sprite = treeGlitch[1];
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
        foreach (SpriteRenderer s in trees1)
        {
            s.sprite = treeNormal[0];
        }
        foreach (SpriteRenderer s in trees2)
        {
            s.sprite = treeNormal[1];
        }
        yield return null;
    }
    private void OnDestroy()
    {
        _GlitchChannel.onEventRaised -= Glitch;
    }
}
