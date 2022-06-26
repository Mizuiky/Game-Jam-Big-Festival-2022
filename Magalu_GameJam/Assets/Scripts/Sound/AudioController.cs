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

    private void Awake()
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

    public void play(string name)
    {
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        sound.source.Play();
    }

    public void stop(string name)
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
        setSoundVolume("DreamBackground", 0.03f);
        //Debug.Log("play gameover");
        play("Victory");
        yield return new WaitForSeconds(0.8f);
        play("Clock");
    }

    public void startBadAwake()
    {
        //Debug.Log("start wake");
        StartCoroutine(badAwakeUp());
    }

    private IEnumerator badAwakeUp()
    {
        stop("Horse");
        stop("DreamBackground");
        //Debug.Log("stop dreambackground");
        setSoundVolume("Nightmare", 0.08f);
        //Debug.Log("play gameover");
        play("WakeUp");
        yield return new WaitForSeconds(0.3f);
        play("GameOver");
    }

    public void setSoundVolume(string name, float volume)
    {
        //Debug.Log("Entered in setsoundvalume");
        Sounds sound = Array.Find(gameSounds, Sounds => Sounds.name == name);
        //Debug.Log("source name " + sound.name);
        sound.source.volume = volume;
        //Debug.Log("volume: " + sound.source.volume.ToString());
    }
}
