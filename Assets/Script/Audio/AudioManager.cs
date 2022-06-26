using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [Header("Event")]
    public StringEventChannelSO _SoundChannelSO;
    [Header("List of sounds")]
    public List<Sound> sounds = new List<Sound>();
    public AudioDataBaseScriptabelObject audioDataBase;

    private void Awake()
    {
        //sub to sfx
        _SoundChannelSO.onEventRaised += PlayAudio;

        DontDestroyOnLoad(gameObject);
        // Add line spell Sound
        foreach(Sound s in audioDataBase.lineSound)
        {
            AddSound(s);
        }        
    }
    private void AddSound(Sound s)
    {
        sounds.Add(s);
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;
    }

    public void PlayAudio(string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        s.source.Play();
        Debug.Log("sound played : " + s.name);
    }
    private void OnDestroy()
    {
        _SoundChannelSO.onEventRaised -= PlayAudio;
    }
}
