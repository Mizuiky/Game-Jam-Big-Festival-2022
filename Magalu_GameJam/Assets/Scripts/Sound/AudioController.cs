using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Core;

public class AudioController : Singleton<AudioController>
{
    [SerializeField] Sounds[] gameSounds;

    // Start is called before the first frame update

    public void Start()
    {
        foreach (Sounds sounds in gameSounds)
        {
            sounds.source = gameObject.AddComponent<AudioSource>();
            sounds.source.clip = sounds.clip;

            sounds.source.volume = sounds.volume;
            sounds.source.pitch = sounds.pitch;
            sounds.source.loop = sounds.loop;

            sounds.source.Stop();
        }
    }

    public void Play(string name)
    {
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);

        Debug.Log(sound.name);
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        sound.source.Stop();
    }

    public void startGoodAwake()
    {
        //Debug.Log("start wake");
        StartCoroutine(goodAwakeUp());
    }

    private IEnumerator goodAwakeUp()
    {
        //Debug.Log("stop dreambackground");
        SetSoundVolume("DreamBackground", 0.03f);
        //Debug.Log("play gameover");
        Play("Victory");
        yield return new WaitForSeconds(0.8f);
        Play("Clock");
    }

    public void startBadAwake()
    {
        //Debug.Log("start wake");
        StartCoroutine(badAwakeUp());
    }

    private IEnumerator badAwakeUp()
    {
        Stop("Horse");
        Stop("DreamBackground");
        //Debug.Log("stop dreambackground");
        SetSoundVolume("Nightmare", 0.08f);
        //Debug.Log("play gameover");
        Play("WakeUp");
        yield return new WaitForSeconds(0.3f);
        Play("GameOver");
    }

    public void SetSoundVolume(string name, float volume)
    {
        //Debug.Log("Entered in setsoundvalume");
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        //Debug.Log("source name " + sound.name);
        sound.source.volume = volume;
        //Debug.Log("volume: " + sound.source.volume.ToString());
    }
}
